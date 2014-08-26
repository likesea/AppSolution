using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace App.Models.Sys
{
    public class SysRightOperateModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name="权限id")]
        public string RightId { get; set; }
        [Display(Name="操作码")]
        public string KeyCode { get; set; }
        [Display(Name="是否验证")]
        public bool IsValid { get; set; }

    }
}
