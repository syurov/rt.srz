﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setting.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using rt.core.model;

namespace rt.srz.model.srz
{
   [DataContract] 
	 [Serializable]
   public partial class Setting : BusinessBase<System.Guid>
   {
      public Setting() { }

	    [XmlElement(Order = 1)]
      [DataMember(Order = 1)]
      public override System.Guid Id
      {
         get
         {
            return base.Id;
         }
         set
         {
            base.Id = value;
         }
      } 

      [XmlElement(Order =  2)]
      [DataMember(Order =  2)]
      public virtual string Name { get; set;}
        
      [XmlElement(Order =  3)]
      [DataMember(Order =  3)]
      public virtual string ValueString { get; set;}
        
      [XmlElement(Order =  4)]
      [DataMember(Order =  4)]
      public virtual System.Guid? UserId { get; set;}
        
        
		  [XmlElement(Order =  5)]
      [DataMember(Order =  5)]
		  public virtual Organisation Organisation { get; set;}
			
        
		  [XmlElement(Order =  6)]
      [DataMember(Order =  6)]
		  public virtual Workstation Workstation { get; set;}
			
   }
}
