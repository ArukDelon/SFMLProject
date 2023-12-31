﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLProject
{
    public class SceneManager
    {
        private List<Scene> scenes;
        private Scene currentScene;

        public SceneManager()
        {
            scenes = new List<Scene>();
        }

        public void AddScene(Scene scene)
        {
            scenes.Add(scene);
        }

        public void RemoveScene(Scene scene)
        {
            scenes.Remove(scene);
        }

        public void SwitchScene(Scene scene)
        {
            currentScene = scene;
        }

        public void SwitchScene(string sceneName)
        {
            try
            {
                for (int i = 0; i < scenes.Count; i++)
                {
                    if (scenes[i].GetName().Equals(sceneName))
                    {
                        currentScene = scenes[i];
                        return;
                    }
                }
                throw new Exception("Scene has not found");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
           
        }


        public void SwitchScene(int sceneID)
        {
            currentScene = scenes[sceneID];
        }

        public void Update()
        {
            currentScene?.Update();
        }

        public void Draw()
        {
            currentScene?.Draw();
        }

        public void ProcessInput()
        {
            currentScene?.ProcessInput();
        }
    }
}
