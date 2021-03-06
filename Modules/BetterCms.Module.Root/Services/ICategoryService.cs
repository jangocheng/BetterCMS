﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICategoryService.cs" company="Devbridge Group LLC">
// 
// Copyright (C) 2015,2016 Devbridge Group LLC
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// 
// <summary>
// Better CMS is a publishing focused and developer friendly .NET open source CMS.
// 
// Website: https://www.bettercms.com 
// GitHub: https://github.com/devbridge/bettercms
// Email: info@bettercms.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using BetterCms.Core.DataContracts;
using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.ViewModels.Category;

using BetterModules.Core.Models;

namespace BetterCms.Module.Root.Services
{
    public interface ICategoryService
    {
        IEnumerable<Guid> GetSelectedCategoriesIds<TEntity, TEntityCategory>(Guid? entityId)
            where TEntity : Entity, ICategorized
            where TEntityCategory : Entity, IEntityCategory;

        IEnumerable<LookupKeyValue> GetSelectedCategories<TEntity, TEntityCategory>(Guid? entityId)
            where TEntity : Entity, ICategorized
            where TEntityCategory : Entity, IEntityCategory;

        void CombineEntityCategories<TEntity, TEntityCategory>(TEntity entity, IEnumerable<LookupKeyValue> currentCategories)
            where TEntity : Entity, ICategorized
            where TEntityCategory : Entity, IEntityCategory, new();

        void CombineEntityCategories<TEntity, TEntityCategory>(TEntity entity, IEnumerable<Guid> currentCategories)
            where TEntity : Entity, ICategorized
            where TEntityCategory : Entity, IEntityCategory, new();

        void DeleteCategoryNode(Guid id, int version, Guid? categoryTreeId = null);

        IEnumerable<Guid> GetChildCategoriesIds(Guid category);

        IEnumerable<Guid> GetCategoriesIds(IEnumerable<string> categoriesNames);

        IList<CategoryLookupModel> GetCategoriesLookupList(string categoriesFilterKey);
    }
}