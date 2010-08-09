using System;

namespace Enyim.Caching.Memcached.Operations.Text
{
	internal sealed class DeleteOperation : ItemOperation2, IDeleteOperation
	{
		internal DeleteOperation(string key) : base(key) { }

		protected override System.Collections.Generic.IList<ArraySegment<byte>> GetBuffer()
		{
			var command = "delete " + this.Key + TextSocketHelper.CommandTerminator;

			return TextSocketHelper.GetCommandBuffer(command);
		}

		protected override bool ReadResponse(PooledSocket socket)
		{
			return String.Compare(TextSocketHelper.ReadResponse(socket), "DELETED", StringComparison.Ordinal) == 0;
		}
	}
}

#region [ License information          ]
/* ************************************************************
 * 
 *    Copyright (c) 2010 Attila Kisk�, enyim.com
 *    
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *    
 *        http://www.apache.org/licenses/LICENSE-2.0
 *    
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *    
 * ************************************************************/
#endregion
