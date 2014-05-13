using System;
using System.IO;
using System.Xml.Serialization;

namespace AndaForceExtensions.com.andaforce.arazect.serialization
{
    public class ConfigurationLoader
    {
        #region Load

        public static T LoadConfiguration<T>(
            String loadPath,
            InfoDelegate onError = null,
            InfoDelegate onSuccess = null)
            where T : IConfigurationObject, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof (T));
                TextReader reader = new StreamReader(loadPath);
                var instance = (T) serializer.Deserialize(reader);
                reader.Close();

                ReportSuccess<T>("Deserialization", loadPath, onSuccess);

                return instance;
            }
            catch (Exception e)
            {
                if (onError != null)
                {
                    ReportError<T>("Deserialization", onError, e);
                }

                var instance = new T();
                instance.InitDefault();
                return instance;
            }
        }


        public static T LoadConfigurationFromString<T>(String source,
            InfoDelegate onError = null,
            InfoDelegate onSuccess = null) where T : IConfigurationObject, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof (T));
                TextReader reader = new StringReader(source);
                var instance = (T) serializer.Deserialize(reader);
                reader.Close();

                ReportSuccess<T>("Deserialization", "Raw source", onSuccess);

                return instance;
            }
            catch (Exception e)
            {
                ReportError<T>("Deserialization", onError, e);

                var instance = new T();
                instance.InitDefault();
                return instance;
            }
        }

        #endregion

        #region Save

        public static void SaveConfiguration<T>(
            T configurationObject,
            String savePath,
            InfoDelegate onSuccess = null,
            InfoDelegate onError = null) where T : IConfigurationObject, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof (T));
                TextWriter writer = new StreamWriter(savePath);
                serializer.Serialize(writer, configurationObject);
                writer.Close();

                ReportSuccess<T>("Serialization", savePath, onSuccess);
            }
            catch (Exception e)
            {
                ReportError("Serialization", onError, e);
            }
        }

        #endregion

        private static void ReportError(String typeMessage, InfoDelegate onError, Exception e)
        {
            if (onError != null)
            {
                onError.Invoke(
                    String.Format("{0} error: {1}", typeMessage, e.Message));
            }
        }

        private static void ReportSuccess<T>(String typeMessage, string path, InfoDelegate onSuccess)
            where T : new()
        {
            if (onSuccess != null)
            {
                onSuccess.Invoke(
                    String.Format("{0} completed with {1} at {2}", typeMessage, typeof (T), path));
            }
        }
    }

    public interface IConfigurationObject
    {
        void InitDefault();
    }

    public delegate void InfoDelegate(String message);
}