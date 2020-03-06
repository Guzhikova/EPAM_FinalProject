﻿using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using DentalOffice.WebUI.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace DentalOffice.WebUI.Management
{
    public class AdministrationModule
    {
        private IUsersLogic _userLogic = DependencyResolver.UsersLogic;
        private IRolesLogic _roleLogic = DependencyResolver.RolesLogic;

        private IPostsLogic _postLogic = DependencyResolver.PostsLogic;


        public bool TryAuthenticateUser(HttpRequestBase request, out string errorMessage)
        {
            errorMessage = "";
            bool isAuthenticated = false;            
            string login = request["login"];
            string password = request["password"];

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                if (_userLogic.isPairLoginPassword(login, password))
                {
                    FormsAuthentication.SetAuthCookie(login, createPersistentCookie: true);
                    isAuthenticated = true;

                    Logger.Log.Info($"The user '{login}'  is successfully authenticated");
                    
                }
                else
                {
                    errorMessage = "Неверная пара логин-пароль! Проверьте регистр и язык на клавиатуре и попробуйте войти снова.";
                    Logger.Log.Warn($"Authentication for user '{login}' rejected: invalid username/password pair");
                }
            }else
            {
                errorMessage = "К сожалению, не удалось получить данные логин/пароль. Обратитесь за помощью к администратору сайта.";
                Logger.Log.Error("Received data from Request about user login and password were null or empty");
            }

            return isAuthenticated;
        }

        public User RegisterUser(HttpRequestBase request)
        {
            string login = request["login"];
            string password = request["password"];
            string email = request["email"];
            DateTime registrationDate = DateTime.Now;
            byte[] image = GetAndResizeImageFromRequest();

            return null;
        }

        public List<Post> GetPosts()
        {
            return _postLogic.GetAll().ToList();
            //ДОПОЛНИТЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬ
        }

        private byte[] GetAndResizeImageFromRequest(int width = 100, int height = 100)
        {
            byte[] imageBytes = null;
            WebImage image = WebImage.GetImageFromRequest();

            if (image != null)
            {
                image.Resize(width, height, false, true);

                imageBytes = image.GetBytes();
            }

            return imageBytes;
        }



    }
}