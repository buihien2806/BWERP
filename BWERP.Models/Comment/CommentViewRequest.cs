using BWERP.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWERP.Models.Comment
{
	public class CommentViewRequest
	{
		public int Id { get; set; }
		public Functions Function { get; set; }
		public string Content { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; } 
		public Guid UpdatedBy { get; set; }
		public DateTime UpdatedDate { get; set; } 
	}
}
