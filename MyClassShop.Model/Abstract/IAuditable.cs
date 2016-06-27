using System;

namespace MyClassShop.Modal.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreateBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdatedBy { set; get; }

        string Metakeyword { set; get; }
        string MetaDescription { set; get; }

        bool Status { set; get; }
    }
}