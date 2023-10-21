using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Asbtract
{
    public abstract class Audit
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public void Create()
        {
            CreatedAt = DateTime.Now;
        }
        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }

        public void GenerateAudit()
        {
            if(CreatedAt == null) {
                Create();
            }
            else
            {
                Update();
            }
        }
    }
}
