게임 유저 데이터(유저레벨, 보유아이템, 사운드 볼륨 등)를 파일에 저장하고 관리하는 기능



UML
![gamedata_a](https://github.com/wyuurla/Unity-GameData/assets/37171461/30de32b6-a5ba-4858-8143-7c145b7710a6)

예 1) GameData_Option(게임 사운드 볼륨을 저장하기 위한 데이터) 추가 하기

GameDataTool를 사용하여 GameData_Option 스크립트 생성
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/1aedacda-7004-48ef-bca4-63403e38a86a)

GameDataCreate 팩토리 함수에 GameData_Option 스크립트 추가
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/f81b9523-e8ee-44bf-879f-2d493d1a7ebd)

GameData_Option 스트립트에 사운드 볼륨 변수에 사용할 sound_volume_bgm, sound_volume_fx 추가
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/d3070d31-f383-4b56-883e-b05e1a0266e4)

GameDataTest_Start에 GameDataManager.Instance.UpdateLogic(); 호출
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/b420534c-4711-46e3-a548-e66ffb88617c)

GameDataTest_Option에 저장된 볼륨으로 Slider 유아이에 적용, "Save"버튼을 클릭하면 파일에 저장한는 코드를 입력
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/0b04851f-8405-4896-8d1f-18e65c56f74a)

GameDataTest_Start스크립트 컨포넌트로 추가
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/4534555f-1c85-44d9-9192-25aa17613e6d)

GameDataTest_Option스크립트 컴포넌트에 추가후 유아이 연결
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/572d7a67-d580-44fd-940b-ffa64d3696e4)

GameDataTest_Option 저장하는 함수를 버튼에 연결
![image](https://github.com/wyuurla/Unity-GameData/assets/37171461/80c5bf02-501f-4d0f-9132-158209d2b44d)

예 2) 점수 저장하기 유튜브 참고.
https://youtu.be/chK1VUSG8qc
