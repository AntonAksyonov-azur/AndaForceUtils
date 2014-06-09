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
            var reader = new StreamReader(loadPath);
            var instance = DeserializeObject<T>(reader, loadPath, onError, onSuccess);
            reader.Close();

            return instance;
        }

        public static T LoadConfigurationFromString<T>(
            String source,
            InfoDelegate onError = null,
            InfoDelegate onSuccess = null) where T : IConfigurationObject, new()
        {
            var reader = new StringReader(source);
            var instance = DeserializeObject<T>(reader, "Raw", onError, onSuccess);
            reader.Close();

            return instance;
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

        #region Report

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
                    String.Format("{0} completed with {1} (source info: {2})", typeMessage, typeof (T), path));
            }
        }

        #endregion

        #region Base Methods

        private static T DeserializeObject<T>(
            TextReader reader,
            String sourceInfo = "Raw",
            InfoDelegate onError = null,
            InfoDelegate onSuccess = null) where T : IConfigurationObject, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof (T));
                var instance = (T) serializer.Deserialize(reader);

                ReportSuccess<T>("Deserialization", sourceInfo, onSuccess);

                return instance;
            }
            catch (Exception e)
            {
                if (onError != null)
                {
                    ReportError("Deserialization", onError, e);
                }
                return CreateDefaultObject<T>();
            }
        }

        private static T CreateDefaultObject<T>() where T : IConfigurationObject, new()
        {
            var instance = new T();
            instance.InitDefault();

            return instance;
        }

        #endregion
    }

    public interface IConfigurationObject
    {
        void InitDefault();
    }

    public delegate void InfoDelegate(String message);
}