using System;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Workstation
    {
        public int Id { get; set; }

        // 外部キーだけでなく、外部キーIDを追加しなければ、スキャフォールディング生成時にDropDownListを生成してくれない
        public virtual int? FabId { get; set; }
        public virtual Fab Fab { get; set; }

        // 外部キーだけでなく、外部キーIDを追加しなければ、スキャフォールディング生成時にDropDownListを生成してくれない
        public virtual int? MachineId { get; set; }
        public virtual Machine Machine { get; set; }

        [DisplayName("装置番号")]
        public int EquipmentNo { get; set; }

        [DisplayName("MACアドレス")]
        public string MapAddress { get; set; }

        [DisplayName("備考")]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("緊急用MACアドレス")]
        public string EmargencyMapAddress { get; set; }
    }
}