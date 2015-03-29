using System;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Member
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { get; set; }

        [DisplayName("ユーザーID")]
        public string UserID { get; set; }

        [DisplayName("会社ID")]
        public string CorporationID { get; set; }

        [DisplayName("会社名")]
        public string CorporationName { get; set; }

        [DisplayName("メールアドレス")]
        public string Email { get; set; }

        [DisplayName("登録日")]
        public DateTime Date { get; set; }

        // 外部キーだけでなく、外部キーIDを追加しなければ、スキャフォールディング生成時にDropDownListを生成してくれない
        public int? RollID { get; set; }

        [DisplayName("役割")]
        public virtual Roll Roll { get; set; }
    }
}