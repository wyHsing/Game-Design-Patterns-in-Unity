using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

//ref: https://github.com/tklee1975/KencoderUnityBasic/blob/521867c360b88d8bec10cfdd81885fb14b59afd6/Assets/_Library/Utility/FileHelper.cs#L7
namespace myHelper
{
    public class FileHelper
    {
        public static string ReadFile(string _path)
        {
            try
            {
                StreamReader reader = new StreamReader(_path);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
            catch(System.Exception e)
            {
                Debug.Log("FileHelper: exception: " + e);
                return null;
            }
        }

        public static string ReadFileFromAsset(string _path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(_path);
            if(textAsset == null)
            {
                Debug.Log("TextAsset is null from " + _path);
                return "";
            }

            return textAsset.text;
        }

        public static void WriteFile(string _path, string _content)
        {
            StreamWriter writer = new StreamWriter(_path);
            writer.Write(_content);

            writer.Close();
        }

        public static void RemoveFile(string _path)
        {
            File.Delete(_path);
        }
    }
}
