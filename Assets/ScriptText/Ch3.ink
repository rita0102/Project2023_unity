你終於來了 #speaker:???
請問你是... #speaker:A #confused
->choice1
=== choice1 ===
VAR choice=0
*鳥嘴醫生？ #speaker:A #confused
    難道你沒有判斷力嗎，怎麼想我都不會是那個黑漆漆的傢伙吧 #speaker:??? #angry
    ~choice=1
*吹笛人？ #speaker:A #confused
    答對了！真不愧是慶典的冠軍 #speaker:吹笛人 #happy
    ~choice=2
-我是這次獎品的提供者，人們口中的吹笛人♩～～ #speaker:吹笛人 #happy

聽說你有事找我？ #speaker:A #confused
應該是你有事要問我吧？ #speaker:吹笛人
->choice2
=== choice2 ===
*難道你知道藥草的下落？ #speaker:A #confused
    我是知道，但這跟你有甚麼關係嗎♪ #speaker:吹笛人
    我正踏上尋找藥草的旅途，希望可以治好村民的疾病。 #speaker:A
    像你這麼單純的人已經不多了......（小聲） #speaker:吹笛人
    好吧～♩ 今天我心情好就告訴你吧♪ #speaker:吹笛人 #happy
	據我所知你應該已經有兩種藥草了吧? #speaker:吹笛人
	然後第三種藥草就在~~ #speaker:吹笛人
    ................................. #speaker:A
    ...在哪裡? #speaker:A
    哼哼，就在這間教堂裡~♪ #speaker:吹笛人 #happy
	驚不驚喜? 意不意外? #speaker:吹笛人 #happy
    那請問在教堂的哪裡呢? #speaker:A
    我已經透漏得夠多了，再說下去會違反規則。 #speaker:吹笛人
    規則? #speaker:A #confused
    這一路上你應該體會夠多次了。 #speaker:吹笛人
    ->choice2
*難道你認識鳥嘴醫生？ #speaker:A #confused
    ...你為什麼會覺得我認識那什麼醫生 #speaker:吹笛人
    {choice==1:你剛才說了黑漆漆的傢伙...|直覺...} #speaker:A
    我最討厭直覺敏銳的小鬼了 #speaker:吹笛人
    看起來你也認識那個醫生，奉勸你不要太信任他 #speaker:吹笛人
    為什麼?我覺得他是很善良的人，而且他還救過我 #speaker:A #confused
    你是在村子裡遇到鳥嘴醫生的吧？ #speaker:吹笛人
    難道你都不會好奇嗎？為甚麼他會出現在那個荒涼的村莊。 #speaker:吹笛人
    ... #speaker:A
    他似乎在做跟你一樣的事情呢 #speaker:吹笛人
    **蒐集藥草嗎... #speaker:A #confused
        沒錯，他要搶在你之前蒐集完，但失敗了 #speaker:吹笛人
    **拯救村莊...? #speaker:A #confused
        哈哈...怎麼可能，他有一點良心，但不多 #speaker:吹笛人
	    拯救村莊對他來說可謂易如反掌，他的目的是要蒐集所有的藥草 #speaker:吹笛人
    --為什麼...難道蒐集藥草不是為了拯救村莊...而是... #speaker:A #confused
    當然是阻止其他人蒐集完藥草後發現事件的真相囉~ #speaker:吹笛人 #happy
    //當然是防止其他人有任何恢復的方法囉~
    !!! #speaker:A #surprise
    好了，你還有甚麼想問的嗎？ #speaker:吹笛人
    ->choice2
*聽說你的笛聲可以治療動物化，可以請你幫忙解救村子嗎？ #speaker:A
    不要～♪ #speaker:吹笛人 #happy
    ㄟ...為甚麼... #speaker:A #sad
    太麻煩了♬所以不要♪  #speaker:吹笛人 #happy
    怎麼這樣... #speaker:A #sad
    ->choice2
*->
- 好~了~♬ 問題應該問完了吧，接下來你就自己好好加油吧♪  #speaker:吹笛人 #happy

【想知道真相，就到城堡裡來】 #speaker:紙條
->DONE


