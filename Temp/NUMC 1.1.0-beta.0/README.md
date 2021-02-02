# NUMC
쉽게 넘패드의 키를 매핑합니다.

# 설명

## 키 지정

### 키 지정 방법

![Form](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/1.png)

[Form](https://github.com/SojuShoveling/NUMC/blob/master/Images/SCREENSHOT/1.png) 에서 지정하고 싶은 키를 마우스 클릭합니다.

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/1-1.png)

샘플 아이템을 선택하거나 사용자 지정 키를 선택합니다.

### 사용자 지정 키 지정 방법

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/2.png)

![ComboBox](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/3.png)

왼쪽 위의 콤보 박스로 사용자 지정 키 방식을 변경할 수 있습니다.   
가상 동시 입력, 가상 키는 텍스트 박스에 마우스를 올려두면 키 후킹을 사용할 수 있습니다.
기본 키는 [System.Windows.Forms.SendKeys.SendWait](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=netcore-3.1)를 참조하세요.

### 매크로 지정 방법

**매크로와 샘플 키 또는 사용자 지정키는 중복이 가능합니다.**

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/4.png)

리스트 뷰에 마우스를 올려두면 키 후킹을 사용할 수 있습니다.

#### 키 입력 추가

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/5.png)

레이블에 마우스를 올려두면 키 후킹을 사용할 수 있습니다.   
키 클릭, 키 누르기, 키 떼기를 선택할 수 있습니다.

#### 텍스트 입력 추가

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/6.png)

텍스트 입력을 추가합니다.

#### 지연 추가

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/7.png)

지연을 추가합니다 단위는 밀리세컨드입니다. 1s = 1000ms

#### 함수 추가

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/8.png)

**함수로 이동** 사용 시 지정한 이름의 함수 위치로 헤더가 이동합니다.

#### 함수로 이동

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/9.png)

지정한 함수로 이동합니다. **함수**를 추가하면 콤보 박스 목록에 추가됩니다.

#### 모든키 떼기

프로그램에서 누른 키를 모두 떼는 이벤트를 추가합니다.

#### 끝내기

매크로를 끝내는 이벤트를 추가합니다.

#### 위, 아래로 이동

선택한 이벤트를 올리거나 내립니다.

#### 이벤트 제거, 이벤트 모두 제거

선택한 이벤트를 제거하거나 모두 제거합니다.

### 알림 아이콘

![NotifyIcon](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/11.png)

알림 아이콘을 더블 클릭하여 설정을 띄웁니다.   
알림 아이콘을 우클릭 하여 컨텍스트 메뉴를 띄웁니다.

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/12.png)

시작 프로그램에 등록하거나 언어를 바꿀 수 있습니다.

### 고급 매뉴

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/13.png)

Json 편집기를 사용할 수 있습니다.

## 프로그램
### 프로그램 종속성
동적 라이브러리 없이 단일 프로그램으로 실행이 가능합니다.   
프로그램에 모든 설정은 (파일 이름).json 으로 저장됩니다. (**NUMC.json**)   
설정 파일을 제거하면 설정은 초기화 됩니다.

# 설명 업데이트 예정
### 마지막 업데이트
#### 1.0.0.0

## 설정 파일

### KeyObject Array
```json
"KeyObject": [
	{
		"Key": 0, // Keys
		"Ignore": true, // 키 무시 여부
		"KeyScript": [
			{
				"Type": "", //키 타입 SendKeys / VirtualKey
				"SendKeys": 
				{
					"Text": [ // System.Windows.Forms.SendKeys.SendWait
						""
					]
				},
				"VirtualKey": // 가상 키
				{
					"Keys":	[ // VKeys
						0
					]
				},
				"Macro": // 매크로
				{
					"AD": true, // 안전 모드 한 키당 한 스레드
					"Code": "" // Macro Code
				}
			}
		]
	}
]
```
### WVKeys Array
```json
"WVKeys": [ // 화이트 리스트 키 | 넘패드 키 외 다른 키 사용 시 등록 필요
	144,
	111,
	106,
	109,
	103,
	104,
	105,
	107,
	100,
	101,
	102,
	97,
	98,
	99,
	13,
	96,
	110
]
```

### Language
```json
"Language": "auto" // 언어 | en-us (기본값), ko-kr
```

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="크리에이티브 커먼즈 라이선스" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />이 저작물은 <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">크리에이티브 커먼즈 저작자표시-비영리-동일조건변경허락 4.0 국제 라이선스</a>에 따라 이용할 수 있습니다.