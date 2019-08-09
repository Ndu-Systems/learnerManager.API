﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class AssetModel
    {
        public Guid AssetId { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
