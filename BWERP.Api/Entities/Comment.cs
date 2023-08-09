using BWERP.Models.Enums;

namespace BWERP.Api.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public Functions Function { get; set; }
		public string Content { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set;} = DateTime.Now;
		public Guid UpdatedBy { get; set; }
		public DateTime UpdatedDate { get; set;} = DateTime.Now;
	}
}
