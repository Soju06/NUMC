# NUMC
���� ���е��� Ű�� �����մϴ�.

# ����

## Ű ����

### Ű ���� ���

![Form](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/1.png)

[Form](https://github.com/SojuShoveling/NUMC/blob/master/Images/SCREENSHOT/1.png) ���� �����ϰ� ���� Ű�� ���콺 Ŭ���մϴ�.

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/1-1.png)

���� �������� �����ϰų� ����� ���� Ű�� �����մϴ�.

### ����� ���� Ű ���� ���

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/2.png)

![ComboBox](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/3.png)

���� ���� �޺� �ڽ��� ����� ���� Ű ����� ������ �� �ֽ��ϴ�.   
���� ���� �Է�, ���� Ű�� �ؽ�Ʈ �ڽ��� ���콺�� �÷��θ� Ű ��ŷ�� ����� �� �ֽ��ϴ�.
�⺻ Ű�� [System.Windows.Forms.SendKeys.SendWait](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=netcore-3.1)�� �����ϼ���.

### ��ũ�� ���� ���

**��ũ�ο� ���� Ű �Ǵ� ����� ����Ű�� �ߺ��� �����մϴ�.**

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/4.png)

����Ʈ �信 ���콺�� �÷��θ� Ű ��ŷ�� ����� �� �ֽ��ϴ�.

#### Ű �Է� �߰�

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/5.png)

���̺��� ���콺�� �÷��θ� Ű ��ŷ�� ����� �� �ֽ��ϴ�.   
Ű Ŭ��, Ű ������, Ű ���⸦ ������ �� �ֽ��ϴ�.

#### �ؽ�Ʈ �Է� �߰�

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/6.png)

�ؽ�Ʈ �Է��� �߰��մϴ�.

#### ���� �߰�

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/7.png)

������ �߰��մϴ� ������ �и��������Դϴ�. 1s = 1000ms

#### �Լ� �߰�

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/8.png)

**�Լ��� �̵�** ��� �� ������ �̸��� �Լ� ��ġ�� ����� �̵��մϴ�.

#### �Լ��� �̵�

![Dialog](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/9.png)

������ �Լ��� �̵��մϴ�. **�Լ�**�� �߰��ϸ� �޺� �ڽ� ��Ͽ� �߰��˴ϴ�.

#### ���Ű ����

���α׷����� ���� Ű�� ��� ���� �̺�Ʈ�� �߰��մϴ�.

#### ������

��ũ�θ� ������ �̺�Ʈ�� �߰��մϴ�.

#### ��, �Ʒ��� �̵�

������ �̺�Ʈ�� �ø��ų� �����ϴ�.

#### �̺�Ʈ ����, �̺�Ʈ ��� ����

������ �̺�Ʈ�� �����ϰų� ��� �����մϴ�.

### �˸� ������

![NotifyIcon](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/11.png)

�˸� �������� ���� Ŭ���Ͽ� ������ ���ϴ�.   
�˸� �������� ��Ŭ�� �Ͽ� ���ؽ�Ʈ �޴��� ���ϴ�.

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/12.png)

���� ���α׷��� ����ϰų� �� �ٲ� �� �ֽ��ϴ�.

### ���� �Ŵ�

![ContextMenu](https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Images/SCREENSHOT/13.png)

Json �����⸦ ����� �� �ֽ��ϴ�.

## ���α׷�
### ���α׷� ���Ӽ�
���� ���̺귯�� ���� ���� ���α׷����� ������ �����մϴ�.   
���α׷��� ��� ������ (���� �̸�).json ���� ����˴ϴ�. (**NUMC.json**)   
���� ������ �����ϸ� ������ �ʱ�ȭ �˴ϴ�.

# ���� ������Ʈ ����
### ������ ������Ʈ
#### 1.0.0.0

## ���� ����

### KeyObject Array
```json
"KeyObject": [
	{
		"Key": 0, // Keys
		"Ignore": true, // Ű ���� ����
		"KeyScript": [
			{
				"Type": "", //Ű Ÿ�� SendKeys / VirtualKey
				"SendKeys": 
				{
					"Text": [ // System.Windows.Forms.SendKeys.SendWait
						""
					]
				},
				"VirtualKey": // ���� Ű
				{
					"Keys":	[ // VKeys
						0
					]
				},
				"Macro": // ��ũ��
				{
					"AD": true, // ���� ��� �� Ű�� �� ������
					"Code": "" // Macro Code
				}
			}
		]
	}
]
```
### WVKeys Array
```json
"WVKeys": [ // ȭ��Ʈ ����Ʈ Ű | ���е� Ű �� �ٸ� Ű ��� �� ��� �ʿ�
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
"Language": "auto" // ��� | en-us (�⺻��), ko-kr
```

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="ũ������Ƽ�� Ŀ���� ���̼���" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />�� ���۹��� <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">ũ������Ƽ�� Ŀ���� ������ǥ��-�񿵸�-�������Ǻ������ 4.0 ���� ���̼���</a>�� ���� �̿��� �� �ֽ��ϴ�.