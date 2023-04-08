using savesystem.dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace savesystem
{
    /// <summary>
    /// This is a simple save and load system in JSON string, but i would most advise you to 
    /// use Mongo Db realm if you wish expand your project after the jam
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        List<Dto> dTOs = new List<Dto>();
        internal void LoadGame()
        {
            dTOs = new List<Dto>();
            dTOs = GetDTOFromJsonString();

            if (dTOs.Count == 0)
            {
                return;
            }

            List<UnityEngine.Object> savables = FindObjectsOfType<UnityEngine.Object>().Where(o => o is ISavable).ToList();

            foreach (Dto dto in dTOs)
            {
                switch (dto)
                {
                    //case Player_DTO player_DTO:
                    //    (savables.Where(s => s is PlayerManager).First() as ISavable).LoadData(player_DTO);
                    //    break;
                }
            }
        }

        /// <summary>
        /// Generates one and only one file that contains all the save data of all your ISavable In the scene
        /// </summary>
        internal void SaveGame()
        {
            dTOs = new List<Dto>();

            List<UnityEngine.Object> savables = FindObjectsOfType<UnityEngine.Object>().Where(o => o is ISavable).ToList();
            savables.ForEach(s => dTOs.Add((s as ISavable).Save()));

            GenerateJsonString();
        }

        private void GenerateJsonString()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };

            try
            {
                string path = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(path + @"\Saves");

                string save_file_path = @$"{path}\Saves\SaveFile.json";
                Debug.Log(save_file_path);
                File.WriteAllText(save_file_path, JsonConvert.SerializeObject(dTOs, settings));

            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        private List<Dto> GetDTOFromJsonString()
        {
            List<Dto> saved_dtos = new List<Dto>();
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };

            string path = Directory.GetCurrentDirectory();

            try
            {
                path = Directory.GetDirectories(path).ToList().Where(dir_path => dir_path.Contains("Saves")).ToList().First();
            }
            catch (Exception e)
            {
                Debug.Log("<color=red> No save files Yet </color>");
                return saved_dtos;
            }


            if (path == null || !path.Contains("Saves"))
            {
                Debug.Log("<color=red> No save files Yet </color>");
                return saved_dtos;
            }
            string save_path = Directory.GetFiles(path)[0];


            try
            {
                saved_dtos = JsonConvert.DeserializeObject<List<Dto>>(File.ReadAllText(save_path), settings);
                return saved_dtos;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return saved_dtos;
            }
        }

        public void DestroySaveFile()
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                path = Directory.GetDirectories(path)?.ToList()?.Where(dir_path => dir_path.Contains("Saves"))?.ToList()?.First();
                Directory.Delete(path, true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

        }
    }
}


