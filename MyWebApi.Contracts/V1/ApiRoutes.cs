﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Contracts.V1
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string GetAll = Base + "/posts";

            public const string Get = Base + "/posts/{postid}";

            public const string Create = Base + "/posts";

            public const string Update = Base + "/posts/{postid}";
            public const string Delete = Base + "/posts/{postid}";
        }
        public static class Tags
        {
            public const string GetAll = Base + "/tags";

            public const string Get = Base + "/tags/{tagName}";

            public const string Create = Base + "/tags";

            public const string Delete = Base + "/tags/{tagName}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
        public static class Menus
        {
            public const string GetAll = Base + "/menus";

            public const string Get = Base + "/menus/{MealId}";

            public const string Create = Base + "/menus";

            public const string Delete = Base + "/menus/{MealId}";

            public const string Update = Base + "/menus/{MealId}";
        }

        public static class Ingredients
        {
            public const string GetAll = Base + "/ingredients";

            public const string Get = Base + "/ingredients/{id}";

            public const string Create = Base + "/ingredients";

            public const string Delete = Base + "/ingredients/{id}";

            public const string Update = Base + "/ingredients/{id}";
        }
    }
}
