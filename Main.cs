/*
 * Program.cs
 * 
 * fin (pseudophpt)
 * 
 * This file is part of N64Obj2DL.
 *
 * N64Obj2DL is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * N64Obj2DL is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with N64Obj2DL.  If not, see <http://www.gnu.org/licenses/>.
 */
 
using System;
using System.Collections.Generic;
using System.Linq;

namespace obj2n64dl
{
	class Program
	{
		private const string helpText = "usage: obj2n64dl <file> <vtx cache size [default 32]>";
		private const string creditsText = "made by fin (pseudophpt) 2017 w/ the help of a balanced breakfast";
		
		public static void Main(string[] args)
		{
			/* Default values */
			string filename = args[0];
			int vtxCacheSize = 32;
			
			if (args[0] == "h") {
				printHelp();
			} else if (args[0] == "c") {
				printCredits();
			} else {
				if (args.Length > 1) {
					/* If cache size specified, set it */
					vtxCacheSize = Convert.ToInt16(args[1]);
				}
				
				/* Triple list :O */
				N64DL obj = new N64DL(filename, vtxCacheSize);
				
				List<List<List<DLVertex3>>> FVertexList = obj.getVertices();
				
				int VertexRound = 0;
				
				foreach (List<List<DLVertex3>> VertexList in FVertexList) {
					Console.WriteLine("static Vtx vtx_array" + VertexRound.ToString() + "[] = ");
					Console.WriteLine('{');
					foreach (List<DLVertex3> Tri in VertexList) {
						foreach (DLVertex3 Vtx in Tri) {
							Console.WriteLine("\t" + Vtx.ToString());
						}
					}
					Console.WriteLine('}');
					/* Increment round number */
					VertexRound ++;
				}
			}
		}
		
		private static void printHelp () {
			Console.WriteLine(helpText);
		}
	
		private static void printCredits () {
			Console.WriteLine(creditsText);
		}
	}
	
	
}