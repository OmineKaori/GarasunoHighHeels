using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// 2016/12/22 いとぅー
/// Assets以下の全ファイルをエクスポートします。
/// Tagを含むパッケージを作成できることが通常のExportPackageと異なる点です。
/// </summary>
namespace ExportPackageUtils
{
	public class ExportPackageWithTagsAndLayers
    {
		[MenuItem("Assets/ExportPackageWithTagsAndLayers")]
		static void ExportPackage(){
			List<string> assets = new List<string>();

            // Assets以下の全ファイルをパッケージに追加
            assets.Add("Assets");
            
            // 各設定ファイルをパッケージに追加
			assets.Add("ProjectSettings/ProjectSettings.asset");
			assets.Add("ProjectSettings/TagManager.asset");

			string packageFileName = Application.productName + ".unitypackage";

			AssetDatabase.ExportPackage(assets.ToArray(), packageFileName,
				ExportPackageOptions.Recurse | 
                ExportPackageOptions.Interactive | 
				ExportPackageOptions.IncludeDependencies
			);
		}
	}
}
