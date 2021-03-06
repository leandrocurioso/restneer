﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    [Table("api_resource_route")]
    public class ApiResourceRouteEntity : AbstractEntity
    {
        [Required]
        public ApiResourceEntity ApiResource { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UriPattern { get; set; }

        [Required]
        public string HttpVerb { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        public bool IsAuthenticated { get; set; }

        [Required]
        public bool IsLogged{ get; set; }
    }
}
