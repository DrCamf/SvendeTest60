using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.Models
{
    public class UserCouserMaterialModel
    {
        public int Id { get; set; }
        public int  UserId { get; set; }
        public int CourseId { get; set; }
        public string MaterialPath { get; set; }
        public DateTime SentDate { get; set; }
    }
}
