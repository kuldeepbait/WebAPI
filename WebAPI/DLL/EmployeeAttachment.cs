//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeAttachment
    {
        public int Id { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Attachment { get; set; }
    }
}
