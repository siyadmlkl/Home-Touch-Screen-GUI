   M S B A M L   `   `   `  ????F  BTouchScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TouchScreenTouchScreen  5   	       TouchScreen.Thermostat   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TouchScreen     5   	     ? Title$  Thermostat1??5   	   $	??220??6   $??214.916??6*    ? 
ResizeMode$ NoResize=?6:    ? WindowStyle$
 None=?6P    J? 	AllowDrop . $??0q?6t    J? SnapsToDevicePixels .  ? Topmost .  ? 	Resources 5	       ?? MergedDictionaries ?? Source?? 5
   
    5      ?? 5      $/ )/TouchScreen;component/Styles/Styles.xaml??6%   5      %    5      ??5      ?? 5   
   	 ?? ImageSource$	 BlackGlass.png??6   .??5      ? 
 ? Cursor$

 Hand??6   $??0,0,10,-0.333q?6   .+?5   
   ?? -   5         ??Name$ Display??5      $
??Left=?6#   $??right=?6>   $??39??6a   $??	29,40,0,0q?6m    ?? TextWrapping$
 Wrap=?6?   $	??Top=?6?   $	??100??6?   
???????$??	Digital-7)?6?   $??40(?6?   $
??23.5??6   ?? 	UndoLimit$	 102??6)  ??6?   Z? ??6  Z? 6)  ?? 5   
   -   5         ??Name$ IncTemp??5         ACbutton#??[  6"   $??5??6D   $
??Left=?6P   $??30??6k   $??
125,94,0,0q?6w   $	??Top=?6?   $??30??6?   
???????$??Webdings)?6?   $??26(?6?   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=?6(  ??6?   Z? ??6?   Z? 6(  ?? 5   
   -   5        $ DecTemp??5      #??[  6"   $??6??6E   $
??Left=?6Q   $??30??6l   $??	55,94,0,0q?6x   $	??Top=?6?   $??30??6?   
???????$??Webdings)?6?   $??26(?6?   $ Animated=?6(  ??6?   Z? ??6?   Z? 6(  ?? 5   
   -   5        $
 ACsw??5      #??[  6   $??1??6B   $
??Left=?6O   $??30??6j   $??125,140,0,0q?6v   $	??Top=?6?   $??30??6?   
???   ?$??Berlin Sans FB)?6?   $??16(?6  ??6?   Z? 6  ?? 5   
   -   5        $ Liv_ACsw??5      #??[  6#   $
??Left=?6F   $??20??6a   $??449,252,0,0q?6m   $	??Top=?6?   $??30??6?   
???   ?$??Calibri)?6?   $??14(?6?   $??1??6  ??6?   Z? ??6  Z? 6  ?? 5   
   -   5        $ ACspeed??5      #??[  6"   $?? ??6E   $
??Left=?6P   $??30??6k   $??
55,140,0,0q?6w   $	??Top=?6?   $??30??6?   
???   ?$??Berlin Sans FB)?6?   $??16(?6?   ??6?   Z? 6  ?? 5   
   -   5        $??x??5      #??[  6   $
??Left=?6?   $??20??6Z   $??185,10,-0.333,0q?6f   $	??Top=?6   $??20??6?   ???	#FF826E6E$??16(?6?   ??6?   Z? 6?   ?? 5   
   $	??FAN??6   $
??Left=?6   $??Center=?69   $	??Top=?6]   $??
50,175,0,0q?6u   $??25??6?   $??12(?6?   $??40??6?    J? Opacity$ 1Q?6?   ???	#FF9393936?   ?? 5   
   $
??AUTO??6   $
??Left=?6   $??Center=?6:   $	??Top=?6^   $??121,175,0,0q?6v   $??25??6?   $??12(?6?   $??40??6?   $ 1Q?6?   ???	#FF9393936?   ?? 5   
   -   5         ??Name$ lblName??5      $?? ??6!   $
??Left=?6,   $??Center=?6G   $	??Top=?6k   $??	25,10,0,0q?6?   $??25??6?   $??12(?6?   $	??155??6?   $ 1Q?6?   ???	#FF9393936?   ?? 5   
   $??C??6   $
??Left=?6   $??Center=?67   $	??Top=?6[   $??
134,52,0,0q?6s   $??34??6?   $??20(?6?   $??25??6?   $ 1Q?6?   
???????$??	Digital-7)?6?   ?? 5    
   $??o??6   $
??Left=?6   $??Center=?67   $	??Top=?6[   $??
120,47,0,0q?6s   $??25??6?   $??16(?6?   $??30??6?   $ 1Q?6?   
???????$??	Digital-7)?6?   ?? 5!   
   $
??TEMP??6   $
??Left=?6   $??Center=?6:   $	??Top=?6^   $??	85,98,0,0q?6v   $??26??6?   $??12(?6?   $??40??6?   $ 1Q?6?   ???	#FF9393936?   5#      5$      