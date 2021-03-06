﻿/*******************************************************************************
 * Copyright (C) 2014 Philipp B. Costa
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *******************************************************************************/
using System;
using System.Reflection;
using System.Text;

namespace Ufc.MpOS.Net.Util
{
	public class Service
	{
		public string Name { get; set; }
		public int Port { get; set; }
		
		public Service(string name, int port)
		{
			Name = name;
			Port = port;
		}

		public override string ToString()
		{
			Type type = this.GetType();
			StringBuilder builder = new StringBuilder(type.Name + "=[");

			foreach (PropertyInfo property in type.GetProperties())
			{
				builder.Append(string.Format("{0}={1}, ", property.Name, property.GetValue(this, null)));
			}

			builder.Remove(builder.Length - 2, 2);
			builder.Append("]");

			return builder.ToString();
		}
	}
}