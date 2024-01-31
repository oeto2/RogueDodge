## Time Keeper

![Title](https://github.com/oeto2/RogueDodge/assets/118743238/8e547c0c-56f0-47cf-83c4-c25838f9ccaf)
![Battle](https://github.com/oeto2/RogueDodge/assets/118743238/65236de8-3acd-4f9d-9e4b-73352df8e7a8)

## 🙋‍♀️ 개요
- 프로젝트 이름 : The Time Keeper
- 프로젝트 기간 : 2024.01.24 ~ 2024.01.31
- 개발 엔진 및 언어 : Unity 2022.3.2f1 & C#


## 👀 게임 소개
- 시간을 좀먹는 이레귤러들을 처치하기 위한 주인공의 모험


## 🛠 구현내용
- **필수요구사항**

    - 게임 화면: 게임을 플레이할 수 있는 화면을 만들어야 합니다. 화면 크기, 배경 등을 설정해야 합니다.


    - 캐릭터: 주인공 캐릭터와 적 캐릭터를 만들고, 이들을 움직일 수 있도록 구현해야 합니다. 주인공 캐릭터는 플레이어의 조작에 따라 움직여야 하며, 적 캐릭터는 일정한 패턴에 따라 움직여야 합니다.
       
    - 총알과 공격: 주인공 캐릭터가 총알을 발사할 수 있도록 구현하고, 적 캐릭터에게 공격을 가할 수 있어야 합니다. 또한, 적 캐릭터의 공격 동작을 정의해야 합니다.


    - 충돌 감지: 총알과 적 캐릭터가 충돌했는지를 감지하고, 충돌 시 적 캐릭터를 제거하고 점수를 증가시켜야 합니다. -> (점수대신 골드로 대체)
        


    - 게임 로직: 게임의 기본 로직을 구현해야 합니다. 게임 시작, 종료, 점수, 생명 등을 관리해야 합니다.
        

        


        
- **선택요구사항**
    - 게임 난이도 조절: 난이도를 조절하기 위해 적의 이동 속도, 총알의 발사 속도, 적의 패턴 등을 조절할 수 있습니다. -> (아이템의 성능과 몬스터의 종류로 난이도 조절)
        

        
    - 아이템 시스템: 게임을 더 흥미롭게 만들기 위해 아이템 시스템을 도입할 수 있습니다. 플레이어가 아이템을 획득하면 임시로 강화되는 아이템, 체력을 회복하는 아이템 등을 추가할 수 있습니다.

        

    - 시각적 효과: 게임에 다양한 시각적 효과를 추가하여 게임의 시각적 품질을 향상시킬 수 있습니다.
        

       
    - 사운드 효과: 게임에 배경 음악과 효과음을 추가하여 게임의 분위기를 높일 수 있습니다.

- **추가구현사항**
   - 타이틀 화면에서 인게임 음악의 볼륨을 조절할 수 있습니다.
   - 상점에서 재화로 아이템을 구매할 수 있습니다.
   - 근거리, 원거리, 보스등 다양한 종류의 몬스터가 존재합니다.
   - 포탈이 존재해 스테이지 클리어시 다음 맵으로 넘어갈 수 있습니다.
