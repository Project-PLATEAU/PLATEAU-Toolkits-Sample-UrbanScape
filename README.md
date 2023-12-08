# UrbanScape
### PLATEAU-SDK-Toolkits-for-Unityを使ったサンプルアプリケーション

PLATEAU-SDK-Toolkits for Unityを用いたシミュレーションアプリケーションの作成方法についてご紹介します。

### 更新履歴

|  2023/12/13  |  UrbanScape　初回リリース|
| :--- | :--- |

# 目次

- [1. サンプルシーンの概要](#1-サンプルシーンの概要)
  * [1-1. Toolkitの利用機能](#1-1-toolkitの利用機能)
- [2. 利用手順](#2-利用手順)
  * [2-1. 必要環境](#2-1-必要環境)
  * [2-2. サンプルシーンのビルド方法](#2-2-サンプルシーンのビルド方法)
  * [2-3. ビルドしたアプリケーションの操作方法](#2-3-ビルドしたアプリケーションの操作方法)   
- [3. サンプルシーンのカスタマイズ方法](#3-サンプルシーンのカスタマイズ方法)
  * [3-1. 3D都市モデルの変更](#3-1-3d都市モデルの変更)
- [4. サンプルシーンのカスタマイズ方法](#4-サンプルシーンのカスタマイズ方法)
  * [4-1. 3D都市モデルの変更](#4-1-3d都市モデルの変更)
  * [4-2. 道路のテクスチャ差し替え](#4-2-道路のテクスチャ差し替え)
  * [4-3. プロップ/アバター/乗り物の配置](#4-3-プロップアバター乗り物の配置)
  * [4-4. ポストエフェクトの適用(HDRP)](#4-4-ポストエフェクトの適用HDRP)

 
# 1. サンプルシーンの概要
## 1-1. 体験の概要
このサンプルシーンを使うことで、都市の景観を綺麗に見せられるようなビューアーアプリを作ることが可能です。<br>
都市でのPV作成などのユースケースを想定したサンプルプロジェクトです。<br>

## 1-2. 利用されているToolkitsの機能


### Rendering Toolkit
- 天候の変更
- 時間変更
- ポストエフェクト

### Sandbox Toolkit
- 人の配置
- 車の配置
- Propsの配置

### Maps Toolkit
- Cesiumを使ったPLATEAUモデルの位置合わせ


# 2. 利用手順
## 2-1. 推奨環境
### OS環境
- Windows11
- macOS Ventura 13.2

### Unity Version
- Unity 2021.3.30


### Rendering Pipeline
- HDRP

Built-in Rendering Pipeline、URPでは動作しません。<br>

## 2-2. サンプルシーンのビルド方法

①Assets/Scenes/UrbanScapeを開きます。<br>
<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_scene.png">


②最初にHDRPに関してのウィザードが表示されることがありますが、閉じてください。
<img width="600" alt="multiplay_sample_hdrpwizard" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/CityRescueMultiPlay/multiplay_sample_hdrpwizard.png">


③メニューよりFile > Build Settingsを選択します。<br>

<img width="600" alt="simulation_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_buildsettings.png">

③Windows, Mac以外になっている場合は、Windows, Macを選択して、画面下部にある「Switch Platform」ボタンを押下し、Platformを切り替えます。<br>
④画面下部にある「Build」ボタンを押下します。出力先を選択してビルドを開始します。


## 2-3. ビルドしたアプリケーションの操作方法

①ビルドしたアプリケーションを開くと、オープニング画面が表示されます。<br>
「始めましょう」ボタンを押下してください。<br>
<img width="600" alt="simulation_sample_title" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_title.png">

②ホームビューに遷移します。このビューではマウス操作によってカメラを回転させることができます。
<img width="600" alt="simulation_sample_firstview" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_firstview.png">

<img width="600" alt="simulation_sample_rotated" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_rotated.png">


③画面右の時間帯変更スライダーを調整すると、シーンの時間帯を変更することができます。

<img width="600" alt="simulation_sample_mornig" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_mornig.png">


<img width="600" alt="simulation_sample_night" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_night.png">


④天候ボタンを押下すると、各天候を調整するためのスライダーが表示されます。スライダーを動かすことで天候の変化が可能です。
<img width="600" alt="simulation_sample_weatherui" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_weatherui.png">

<img width="600" alt="simulation_sample_rain" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_rain.png">

<img width="600" alt="simulation_sample_snow" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_snow.png">

<img width="600" alt="simulation_sample_cloudy" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_cloudy.png">


⑤固定カメラ１ボタンを押下すると、人や車の通行が確認できる定点カメラビューに遷移します。<br>

<img width="600" alt="スクリーンショット 2023-12-04 14 13 17" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/assets/137732437/ec43d0d7-ba8b-4978-9eb7-f69ad6111ba3">



⑤固定カメラ２ボタンを押下すると、俯瞰視点の定点カメラビューに遷移します。このカメラには「トイカメラ」のポストエフェクトが適用されています。<br>

<img width="600" alt="simulation_sample_toycamera" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_toycamera.png">

⑥ホームボタンを押すと、ホームビューに戻ります。<br>
<img width="600" alt="simulation_sample_firstview" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_firstview.png">


⑦歩いているHumanや走っているVehicleをクリックすると、カメラインタラクションモードに入ります。左に表示される数字ボタンを押すと視点を切り替えることができます。<br>


「1」ボタンを押下すると一人称視点モードに変わります。<br>

<img width="600" alt="スクリーンショット 2023-12-04 13 58 30" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/assets/137732437/a0ff6643-4d0e-477e-a31e-3754d3ae73c7">


「2.」ボタンを押下すると三人称視点モードに変わります。<br>

<img width="600" alt="スクリーンショット 2023-12-04 13 58 36" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/assets/137732437/8db28f45-aefd-4c87-9253-f99ae014f78e">

「3」ボタンを押下すると見回しモードに変わります。<br>

<img width="600" alt="スクリーンショット 2023-12-04 13 58 40" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/assets/137732437/e4941b22-0ed0-44af-b8a3-1531c75175eb">



詳しくはSandbox Toolkitの[カメラインタラクションについて](https://github.com/unity-shimizu/PLATEAU-SDK-Toolkits-for-Unity/blob/main/PlateauToolkit.Sandbox/README.md#3-%E3%82%AB%E3%83%A1%E3%83%A9%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%A9%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E6%A9%9F%E8%83%BD)をご確認ください。



# 3. サンプルシーンのカスタマイズ方法
## 3-1. 3D都市モデルの変更

シーンをカスタマイズし、PLATEAU都市モデルや配置物を変更したい場合は"Assets/Simulation.unity"をひらき、シーンを編集します。

<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_scene.png">

PLATEAU都市モデルを変更する場合はヒエラルキーの中の"CesiumGeoreference"の中にあるPLATEAU都市モデルを削除した上で、ご自身でインポートしたPLATEU都市モデルを同じ場所に配置してください。

<img width="600" alt="multiplay_sample_customize_cesium" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/CityRescueMultiPlay/multiplay_sample_customize_cesium.png">

> **Note**
> PLATEAUの都市モデルのインポートはPLATEAU SDK for Unityを利用して行ってください。
> （[都市モデルのインポート](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html)）
> 本サンプルで使われているPLATEAUモデル位置合わせ機能はMaps Toolkitの機能です。（[PLATEAUモデル位置合わせ - Maps Toolkit](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/blob/main/maps_toolkit.md#1-plateau%E3%83%A2%E3%83%87%E3%83%AB%E4%BD%8D%E7%BD%AE%E5%90%88%E3%82%8F%E3%81%9B)）



# 4. 3D都市モデルを使った都市景観作成時のTips
3D都市モデルを使って都市景観を作成する際には、利用するデバイスに応じてモデルを最適化することが重要です。
また、テクスチャを差し替えたり、現実の都市空間にあるものをプロップスとして配置したりするなどの工夫で外観のクオリティを高めることができます。
本セクションでは、このサンプルシーンを構築する際に行った景観クオリティ向上のための手順をご紹介します。

## 4-1. サンプル都市モデルの作成

### PlateauSDKでの都市モデルの読み込み
PlateauSDKを使用して都市モデルを読み込みます。

<img width="400" alt="simulation_sample_import1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_import1.png">

<img width="600" alt="simulation_sample_import2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_import2.png">

### RenderingToolkitでの環境システムの作成
RenderingToolkitを使用して環境システムを作成します。ワンクリックで高品質なライティング環境がセットアップされます。

<img width="400" alt="simulation_sample_create_environment" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_create_environment.png">

<img width="600" alt="simulation_sample_apply_environment" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_apply_environment.png">

### AutoTexturingの実行
ビルを選択し、RenderingToolkitのAutoTexturing機能を実行します。環境システムの Time of Day スライダーを調整して時間帯を夜にすると、街灯りが灯ります。雨や雪の天候変化にも対応します。

<img width="600" alt="simulation_sample_select_buildings" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_select_buildings.png">

<img width="400" alt="simulation_sample_apply_texturing1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_apply_texturing1.png">

<img width="400" alt="simulation_sample_apply_texturing2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_apply_texturing2.png">

<img width="600" alt="simulation_sample_apply_texturing3" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_apply_texturing3.png">


### CesiumでのPlateau地面タイルの読み込み
CesiumとMapToolkitの位置合わせ機能を利用してPlateauの地面タイルを読み込み、遠景として使用します。ここまでのステップで基本的な景観設定が完了します。

<img width="600" alt="simulation_sample_cesium_tile2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_cesium_tile2.png">

<img width="600" alt="simulation_sample_result1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_result1.png">

<img width="600" alt="simulation_sample_result2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_result2.png">


### 窓の調整
ビルの形状によっては窓が不自然に見える場合があるため、RenderingToolkitの窓の調整機能を使用して調整が可能です。

<img width="600" alt="simulation_sample_window_adjust1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_window_adjust1.png">

<img width="600" alt="simulation_sample_window_adjust2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_window_adjust2.png">

## 4-2. 道路や地面の調整のTips

### 地面の修正
Plateauの地面のメッシュはところどころ凹んでいる部分がある為、Probuilderを使用して修正していきます。まずは地面のメッシュをProbuilderで編集可能なオブジェクトに変換します。

<img width="600" alt="simulation_sample_road_cleanup1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_road_cleanup1.png">
<br>

地面のメッシュを選択して メニュー >  Tools > ProBuilder > ProBuilder Window > Probuilderize　を実行
<img width="600" alt="simulation_sample_probuilder_fix2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_probuilder_fix2.png">
<br>

凹んでいる箇所の頂点群を選択してY軸に対してスケーリングを行うと、凹んでいる箇所の頂点がフラットになります。これを必要な部分に行い地面のクリーンアップは完了です。

<img width="600" alt="simulation_sample_probuilder_fix3" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_probuilder_fix3.png">

<img width="600" alt="simulation_sample_probuilder_fix4" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_probuilder_fix4.png">

<img width="600" alt="simulation_sample_road_cleanup1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_road_cleanup1.png">

<img width="600" alt="simulation_sample_road_cleanup2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_road_cleanup2.png">
<br>

### 道路の修正
Plateauの道路メッシュを地面の上に移動します。道路はフラットな為、必要に応じて適宜Probuilderで調整を行います。次にサンプルのMaterialsフォルダーに用意された、Roadマテリアルを適用します。プラナーマッピングという手法で、UVがなくてもテクスチャの模様が平面的に張られます。

<img width="600" alt="simulation_sample_road_texturing1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_road_texturing1.png">

<img width="600" alt="simulation_sample_road_texturing2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_road_texturing2.png">
<br>

### 建物の下のタイル敷設
SandboxToolkitを使用して建物の下にタイルを配置します。こちらも建物の形状に合わせて適宜Probuilderで調整を行います。

<img width="600" alt="simulation_sample_tile_placement1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_tile_placement1.png">

<img width="600" alt="simulation_sample_tile_placement2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_tile_placement2.png">

<img width="600" alt="simulation_sample_tile_placement3" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_tile_placement3.png">
<br>

### センターラインの配置
SandboxToolkitのインスタンス配置機能を使用してトラックに沿ってセンターラインを配置します。
<img width="600" alt="simulation_sample_centerline1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_centerline1.png">

<img width="600" alt="simulation_sample_centerline2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_centerline2.png">

<img width="600" alt="simulation_sample_centerline3" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_centerline3.png">
<br>

## Probuilderのインストール方法

ProbuilderはUnity公式のモデリングツールで、ポリゴンベースのモデリング、テクスチャリング、編集作業をUnity内で簡単に行うことができます。これを使用するためには、Unityのパッケージマネージャーからインストールする必要があります。

- ステップ1: Unityエディター内で「Window」メニューを開き、「Package Manager」を選択します。
- ステップ2: パッケージマネージャーウィンドウで「Probuilder」を検索します。
- ステップ3: Probuilderパッケージを見つけたら、「Install」ボタンをクリックしてインストールを開始します。
  
<img width="600" alt="simulation_sample_probuilder_install1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_probuilder_install1.png">
<br>

## ヒエラルキーのカスタム選択機能の使用例

Unityのヒエラルキーでのカスタム選択機能は、複雑な階層を持つシーンで、特定のコンポーネントやタグを持つオブジェクトを一括で選択するのに役立ちます。カスタム選択機能を使用するには メニュー > Edit > Preferences の SearchタブでSceneの項目をAdvancedに設定する必要があります。

<img width="600" alt="simulation_sample_custom_selection1" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_custom_selection1.png">

- 使用例: ヒエラルキーパネルの検索バーに特定の条件を入力します。例えば、「t:MeshRenderer」と入力すると、すべてのメッシュレンダラーを持つオブジェクトが表示されます。
- カスタム検索の利点: カスタム検索を使用することで、プロジェクト内の特定のタイプのオブジェクトや特定の機能を持つオブジェクトをすばやく見つけることができます。
<br>

現在のシーンで表示されているPlateauの建物を一括選択する場合は "bldg t:MeshRenderer p(m_IsActive)=true"と入力します。

<img width="600" alt="simulation_sample_custom_selection2" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_custom_selection2.png">
<br>


##  4-3. プロップ/アバター/乗り物の配置

Sandbox Toolkitの機能を使ってシーンにプロップ/アバター/乗り物を配置し、さまざまなカスタマイズができます。<br>
詳しくは[Sandbox Toolkitの使い方](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/blob/main/sandbox_toolkit.md)をご確認ください。

プロップの配置<br>
<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_customize_props.png">

アバターの配置<br>
<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_customize_human.png">

乗り物の配置<br>
<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_customize_vehicle.png">



##  4-4. ポストエフェクトの適用(HDRP)

HDRPのプロジェクトではCustomPassを使ってポストエフェクトを設定することができます。本サンプルシーンではToy Cameraが設定されています。Custom Pass Volumeの中のTarget Cameraを変更することで、ポストエフェクトを設定するカメラを変更することが可能です。<br>

詳しくは[ポストエフェクトの使い方](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity/blob/main/rendering_toolkit.md#5-%E3%83%9D%E3%82%B9%E3%83%88%E3%82%A8%E3%83%95%E3%82%A7%E3%82%AF%E3%83%88
)をご確認ください。

<img width="600" alt="multiplay_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-Toolkits-for-Unity-drafts/blob/main/SampleSceneReadmeImages/UrbanScape/simulation_sample_posteffect.png">




