using ElasticsearchCRUD;
using ElasticsearchCRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Business.Repository.Impl
{
	public class EmployeeToLowerExampleElasticsearchMapping : ElasticsearchMapping
	{
		public override void MapEntityValues(EntityContextInfo entityInfo, ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter, bool beginMappingTree = false, bool createPropertyMappings = false)
		{
			var propertyInfo = entityInfo.Document.GetType().GetProperties();
			foreach (var prop in propertyInfo)
			{
				MapValue(prop.Name, prop.GetValue(entityInfo.Document), elasticsearchCrudJsonWriter.JsonWriter);
			}
		}

		public override string GetDocumentType(Type type)
		{
			return type.Name.ToLower();
		}
	}

}