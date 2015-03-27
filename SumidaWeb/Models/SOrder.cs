using System;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class SOrder
    {
        public int Id { get; set; }

        [DisplayName("装置")]
        public int MachineID { get; set; }

        [DisplayName("機能識別名称")]
        public string LicenseName { get; set; }

        [DisplayName("機能正式名称")]
        public string LicenseDetail { get; set; }

        [DisplayName("日本語詳細説明")]
        public string LicenseJap { get; set; }

        [DisplayName("英語詳細説明")]
        public string LicenseEng { get; set; }

        public DateTime Date { get; set; }
    }
}