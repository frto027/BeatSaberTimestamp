# BeatSaber Timestamp Mod

A mod used to measure graph delay for your device.

# BeatSaber时间戳Mod

一个可以用来测量图像延迟的节奏光剑mod，并不是拿来玩游戏用的。它会在画面上显示一个时钟，把vr设备和显示器一起录下来，然后比较差值，即可知道vr设备的画面延迟。注意，这只是相对于显示器的延迟！

此mod只能测试到“帧”的程度，并为更细粒度的测量提供运动画面。如果要测量更细的尺度，请准备一个好的摄像头。

# 使用说明

给你的BeatSaber打好基础mod，然后在[release](https://github.com/frto027/BeatSaberTimestamp/releases)下载最新的BSTimestamp.dll文件，把它放在游戏的Plugins目录里面。

测完以后记得删掉。

# 提醒

延迟测量受到各种因素的影响，不同测量方法之间可能不具有可比性。此方法与其它方法的测量结果很可能不具备可比性，请谨慎得出结论！

# 个人测试数据

以下数据仅供参考。注意，此数据不含操作延迟的测量，这一延迟在VirtualDesktop中体感明显。

设备：Quest2
方式|刷新率|游戏启动方式|典型下限（延迟不低于此值，不高于此值加一帧的时间）
----|----|----|----
有线(铜线USB3.1) |72hz|oculus|14ms
有线(三方光纤线) |72hz|oculus|14ms
有线(铜线USB3.1) |72hz|steamvr|29ms
有线(铜线USB3.1) |120hz|oculus|8ms
有线(铜线USB3.1) |120hz|steamvr|16ms
VirtualDesktop|72hz|steamvr|42ms
