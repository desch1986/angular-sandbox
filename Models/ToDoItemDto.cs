using System;
using Newtonsoft.Json;
using AngularSandbox.Repositories.Entities;

namespace AngularSandbox.Models
{
    public class ToDoItemDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}