﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Twin.cs" company="Альянс">
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
   public partial class Twin : BusinessBase<System.Guid>
   {
      public Twin() { }

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
		  public virtual InsuredPerson FirstInsuredPerson { get; set;}
			
        
		  [XmlElement(Order =  3)]
      [DataMember(Order =  3)]
		  public virtual InsuredPerson SecondInsuredPerson { get; set;}
			
        
		  [XmlElement(Order =  4)]
      [DataMember(Order =  4)]
		  public virtual Concept TwinType { get; set;}
			
      [XmlIgnore]
      [IgnoreDataMember]
      public virtual IList<TwinsKey> TwinsKeys { get; set;}
      
   }
}
