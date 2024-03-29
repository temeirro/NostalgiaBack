﻿using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddCustomServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<ICategoriesService, CategoriesService>();
            servicesCollection.AddScoped<ITagsService, TagsService>();
            servicesCollection.AddScoped<IPostImageService, PostImagesService>();
            servicesCollection.AddScoped<IFilesService, FilesService>();
            servicesCollection.AddScoped<IPostsService, PostsService>();
            servicesCollection.AddScoped<IAccountsService, AccountsService>();
        }
    }
}
