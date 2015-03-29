using System;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Output
    {
        public int Id { get; set; }

        // TODO Workstationの識別名として何が表示されるのか？
        public virtual int? WorkstationId { get; set; }
        public virtual Workstation Workstation { get; set; }

        // TODO SOrderの識別名として何が表示されるのか？
        public virtual int? SOrderId { get; set; }
        public virtual SOrder SOrder { get; set; }

        [DisplayName("発行有無")]
        public bool PublicationApproval { get; set; }

        public virtual int? MemberId { get; set; }
        public virtual Member Member { get; set; }

        [DisplayName("発行日")]
        public DateTime PublicationData { get; set; }

        [DisplayName("有効性")]
        public string Validity { get; set; }

        [DisplayName("ダウンロード有無")]
        public bool DownloadStat { get; set; }

        [DisplayName("ダウンロード日付")]
        public DateTime DownloadDate { get; set; }

        [DisplayName("ダウンロード数")]
        public int DownloadNum { get; set; }

        [DisplayName("緊急ライセンス")]
        public bool EmergencyStat { get; set; }
    }
}