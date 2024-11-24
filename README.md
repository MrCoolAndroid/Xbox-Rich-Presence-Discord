# Xbox Rich Presence

*Note: Discord already haves an integrated presence for Xbox Live, but if you want to show more information about what you are playing on Xbox Live you can use this*

***Another note: Please before doing anything read this README, many people tried to clone the repository instead of downloading the release***

## This Rich Presence contains:
1. Game/app name
2. Game/app image (not all games/apps haves an image, you can add images by [contributing](https://github.com/MrCoolAndroid/Xbox-Rich-Presence-Discord#contribute))
3. Timestamp
4. Device name (Xbox One, Xbox 360, etc) and image
5. Xbox Live Rich Presence (if game/app supports it)

## Example
![logo](https://github.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/raw/main/Example2.png)


## Installation
1. Download the [latest release](https://github.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/releases) and extract the .zip file to any folder you like, then just run the .exe file (I recommend creating a shortcut on the desktop for quick access). If it asks you to install .NET, you'll need to download it from [here](https://download.visualstudio.microsoft.com/download/pr/b6fe5f2a-95f4-46f1-9824-f5994f10bc69/db5ec9b47ec877b5276f83a185fdb6a0/windowsdesktop-runtime-5.0.17-win-x86.exe) (x86) or [here](https://download.visualstudio.microsoft.com/download/pr/3aa4e942-42cd-4bf5-afe7-fc23bd9c69c5/64da54c8864e473c19a7d3de15790418/windowsdesktop-runtime-5.0.17-win-x64.exe) (x64), depending on your system.

2. Go to [OpenXBL](https://xbl.io) and login with your Xbox Live account and you will get an API key, save it on a .txt file

3. Open the app and insert your Gamertag and API key

4. Press Start!


## To-Do list
- [ ] Show Xbox Live party
- [ ] Multi-language Rich Presence
- [x] GUI App
- [x] Database for games
- [x] Cool animations and effects
- [x] Device selector
- [x] SteamGridDB support

## Contribute
You can contribute to the source code of the app, I've added it on the Xbox Discord Presence folder as well with its solution, feel free to make pull requests!

_I'm relatively new to GitHub and open-source, so if I'm doing something wrong don't hesitate to tell me_

Wanna contribute on adding games with pictures and backgrounds? Now you can! Just do a pull request editing the [Games List.json](https://github.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/blob/main/Games%20List.json) file!
- "titlename" should have the original name of the game that shows on Xbox, remove any Copyright or Trademark symbols
- Images on "titleicon" should be 1024x1024 and the link to it should be 256 characters maximum and "titlebackground" can be any size but choose one that fits on the app correctly
- "titleimage" is a Discord parameter, give it any name or the game name, i will edit it after the pull request
- "type" (number) is the kind of game or app, Use the following numbers depending of the type of app or game:
  - (1) For games, it will show "Playing (game)"
  - (2) For video apps, it will show "Watching (app)"
  - (3) For another kind of apps, it will show "Using (app)"

## Contributors
People that helped me creating the app!
- Klaudex17 (Games pictures and design)


People who contributed adding games!:

<a href="https://github.com/MrCoolAndroid/Xbox-Rich-Presence-Discord/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=MrCoolAndroid/Xbox-Rich-Presence-Discord" />
</a>

*Made with [contrib.rocks](https://contrib.rocks).*

And many people on Discord!

If you're not seeing any image while playing your game or you need help with anything else, join to my [Discord](https://discord.gg/y22ujrB5e2) and i will gladly help you!

## Games List.json Status

| Game Title | Link | Status |
| --- | --- | --- |
| DRAGON BALL: Sparking! ZERO | [Image link](https://media.vandal.net/m/13/136622/dragon-ball-sparking-zero-2024101110434740\_1.jpg) | ✔ |
| Test Drive Unlimited | [Image link](https://assets-prd.ignimgs.com/2023/12/23/tdu1-1703350705146.jpg) | ✔ |
| Test Drive Unlimited 2 | [Image link](https://cdn2.steamgriddb.com/grid/9ed3fca2a9d9d1ddc50efedc993d14ae.jpg) | ✔ |
| Aliens vs Predator | [Image link](https://assets-prd.ignimgs.com/2022/01/20/aliens-vs-predator-2010-button-1642656901312.jpg) | ✔ |
| Blazblue: Calamity Trigger | [Image link](https://cdn2.steamgriddb.com/thumb/b0302bb8590ad20a617b8d7ceb4caf9f.png) | ✔ |
| Age Of Booty | [Image link](https://cdn2.steamgriddb.com/thumb/ebe6eaa8d941d230e93496709db638b9.jpg) | ✔ |
| Street Fighter X Tekken | [Image link](https://assets-prd.ignimgs.com/2022/01/07/street-fighter-x-tekken-button-1641591107711.jpg) | ✔ |
| HALF-MINUTE HERO -Super Mega Neo Climax- | [Image link](https://cdn2.steamgriddb.com/thumb/8948de2725f465ef6b3760f3550804b3.jpg) | ✔ |
| Marvel Ultimate Alliance 2 | [Image link](https://oyster.ignimgs.com/mediawiki/apis.ign.com/marvel-ultimate-alliance-2/7/72/Marvel\_Ultimate\_Alliance\_2\_-\_BUTTON.jpg) | ✔ |
| Marvel Ultimate Alliance | [Image link](https://assets2.ignimgs.com/2016/07/25/marvel-ultimate-alliance-1-buttonjpg-a2d4d0.jpg) | ✔ |
| Crackdown | [Image link](https://assets-prd.ignimgs.com/2022/02/26/crackdown-sq3-1645908376125.jpg) | ✔ |
| Project Gotham Racing 4 | [Image link](https://cdn2.steamgriddb.com/thumb/7c57d0b5b9fab29ba9f3e317cc71033f.jpg) | ✔ |
| Black Myth: Wukong | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202405/2117/bd406f42e9352fdb398efcf21a4ffe575b2306ac40089d21.png) | ✔ |
| Transformers Devastation | [Image link](https://cdn2.steamgriddb.com/grid/119f6e15c52017fe153a4350ba3413ce.jpg) | ✔ |
| Eternal Sonata | [Image link](https://assets-prd.ignimgs.com/2022/03/07/eternalsonata-1646675939005.jpg) | ✔ |
| Tom Clancy's Ghost Recon Future Soldier | [Image link](https://assets-prd.ignimgs.com/2022/01/04/tom-clancys-ghost-recon-future-soldier-button-1641281459594.jpg) | ✔ |
| RezHD | [Image link](https://cdn2.steamgriddb.com/thumb/453166dfc023f0fbaca96f103a21ed26.jpg) | ✔ |
| Harms Way | [Image link](https://assets-prd.ignimgs.com/2022/03/21/harmsway-1647904582252.jpg) | ✔ |
| Persona 4 Arena Ultimax | [Image link](https://assets-prd.ignimgs.com/2022/01/21/persona-4-arena-ultimax-button-1642751292503.jpg) | ✔ |
| Comic Jumper | [Image link](https://assets-prd.ignimgs.com/2022/03/21/comicjumper-1647878725513.jpg?width=1024&crop=1%3A1%2Csmart&auto=webp) | ✔ |
| Fire Pro Wrestling | [Image link](https://assets-prd.ignimgs.com/2023/06/27/fireprox-1687895281955.jpg?width=1024) | ✔ |
| Alien Isolation | [Image link](https://assets-prd.ignimgs.com/2021/12/15/alien-isolation-button-fin-1639607046894.jpg?width=1024) | ✔ |
| Carcassonne | [Image link](https://xbox360media.ign.com/xbox360/image/object/850/850005/XBL\_Carcassonne.jpg?width=250&crop=1%3A1%2Csmart&auto=webp) | ❓ |
| Midnight Club L.A | [Image link](https://assets-prd.ignimgs.com/2022/01/10/midnightclubla-sq-1641839670810.jpg?width=1024) | ✔ |
| BlazBlue Continuum Shift | [Image link](https://assets-prd.ignimgs.com/2022/03/03/blazblueextend-1646342239729.jpg?width=1024) | ✔ |
| Rock Of Ages | [Image link](https://assets-prd.ignimgs.com/2022/01/19/rock-of-ages-1-button-1642582677635.jpg?width=1024) | ✔ |
| Persona 4 Arena | [Image link](https://assets-prd.ignimgs.com/2022/01/21/persona-4-arena-button-1642751368674.jpg) | ✔ |
| Raskulls | [Image link](https://assets-prd.ignimgs.com/2022/04/22/raskulls-1650586617976.jpg) | ✔ |
| Street Fighter III Third Strike: Online Edition | [Image link](https://assets1.ignimgs.com/2019/01/18/stret-fighter-iii-third-strike-online---button-1547852624330.jpg) | ✔ |
| Assassin's Creed | [Image link](https://cdn2.steamgriddb.com/icon/ef56dd28c084d86aeb28f3b391e94548/32/256x256.png) | ✔ |
| Assassin's Creed Brotherhood | [Image link](https://cdn2.steamgriddb.com/icon/56535b943d33605c7231405ac564d698/32/256x256.png) | ✔ |
| Assassin's Creed II | [Image link](https://cdn2.steamgriddb.com/icon/b67fb3360ae5597d85a005153451dd4e/32/256x256.png) | ✔ |
| Assassin's Creed Revelations | [Image link](https://cdn2.steamgriddb.com/icon/1ea97de85eb634d580161c603422437f/32/256x256.png) | ✔ |
| Assassin's Creed Rogue | [Image link](https://cdn2.steamgriddb.com/icon/77ec6f21c85b637cc42bb997841e11a6/32/256x256.png) | ✔ |
| Assassin's Creed III | [Image link](https://cdn2.steamgriddb.com/icon\_thumb/53b79303779db833f34a053df5a6c111.png) | ✔ |
| FINAL FANTASY XIII | [Image link](https://cdn2.steamgriddb.com/icon/9c509b71f28ed054340ab236be2f83bd/32/512x512.png) | ✔ |
| Castlevania: SOTN | [Image link](https://cdn2.steamgriddb.com/icon\_thumb/c23497bd62a8f8a0981fdc9cbd3c30d9.png) | ✔ |
| Sonic Generations | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/icon/7d822b455dfe04415f0798e0d2105a13/32/256x256.png) | ✔ |
| SONIC X SHADOW GENERATIONS | [Image link](https://cdn2.steamgriddb.com/grid/5cf3903f2f82b49fc603774ce43d6f57.png) | ✔ |
| ぷよぷよテトリス2 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202010/1302/ZGFxG5ChTMDDBckd6UdRLzvm.png) | ✔ |
| Puyo Puyo Tetris 2 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202010/0718/AUtNlbgma7fjJwmet5jwwv6R.png) | ✔ |
| ぷよぷよテトリス | [Image link](https://image.api.playstation.com/cdn/JP0177/CUSA01005\_00/DsB0VEi0mMS2H1mHJskPnALUGzq9RAeb.png) | ✔ |
| Puyo Puyo Champions | [Image link](https://assets1.ignimgs.com/2019/05/08/puyo-puyo-champions---button-fin-1557346889660.jpg) | ✔ |
| Minecraft | [Image link](https://cdn.icon-icons.com/icons2/2699/PNG/512/minecraft\_logo\_icon\_168974.png) | ✔ |
| DayZ | [Image link](https://media.vandal.net/m/20846/dayz-201953013153533\_11.jpg) | ✔ |
| eFootball PES 2021 Season Update | [Image link](https://image.api.playstation.com/vulcan/img/rnd/202011/0201/DCT1LwEUb8fXfS2PZfkzXV59.png) | ✔ |
| Halo: Reach | [Image link](http://pm1.narvii.com/6423/0ef2284f8759f9ccb48260f5f0acdfbb5bac7266\_00.jpg) | ✔ |
| FAR CRY6 | [Image link](https://cdn2.steamgriddb.com/icon/712775bacd00b61567ca8eeb605853c8/32/256x256.png) | ✔ |
| Far Cry 4 | [Image link](https://cdn2.steamgriddb.com/grid/ecc1590d3048696e95539450bd231df1.jpg) | ✔ |
| Far Cry 3 | [Image link](https://cdn2.steamgriddb.com/grid/3754eedc3c390ad0f0fc9a5d9f1495d8.jpg) | ✔ |
| Severed Steel | [Image link](https://cdn2.steamgriddb.com/grid/6ee2932dcc38491002435edbde875246.jpg) | ✔ |
| Call of Duty: Modern Warfare | [Image link](https://sm.ign.com/t/ign\_latam/cover/c/call-of-du/call-of-duty-modern-warfare\_6sub.1024.jpg) | ✔ |
| Fortnite | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202311/2801/803e41fee0edf8f8ed1de518e6eac60ddf30ac485b9a16a2.png) | ✔ |
| Call of Duty: Black Ops Cold War | [Image link](https://sm.ign.com/t/ign\_es/game/c/call-of-du/call-of-duty-black-ops-cold-war\_tsew.1024.jpg) | ✔ |
| Battlefield Hardline | [Image link](https://image.api.playstation.com/cdn/UP0006/CUSA00625\_00/2I1fQbmQZ0ZYbOVHKcHzxDjrI192JuEQ.png) | ✔ |
| Halo: The Master Chief Collection | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/29b378b88c3798599f78f774efa6c521.jpg) | ✔ |
| Back 4 Blood | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202011/1900/sSZEg1DFAUrfWsA7ltLwpCdu.png) | ✔ |
| Minecraft: Story Mode - Season Two | [Image link](https://assets1.ignimgs.com/2017/08/03/minecraft-story-mode-season-2---button-1501797034951.jpg?width=1024) | ✔ |
| Grand Theft Auto V | [Image link](https://image.api.playstation.com/cdn/UP1004/CUSA00419\_00/bTNSe7ok8eFVGeQByA5qSzBQoKAAY32R.png) | ✔ |
| GTA V | [Image link](https://image.api.playstation.com/cdn/UP1004/CUSA00419\_00/bTNSe7ok8eFVGeQByA5qSzBQoKAAY32R.png) | ✔ |
| GTA IV | [Image link](https://www.fayerwayer.com/resizer/4gdSuTwZXtyIze2E34gKL8g45x8=/1024x1024/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/metroworldnews/OXERM3AVUBDQDLUGS7HLPGD3QM.jpg) | ✔ |
| Forza Horizon 5 | [Image link](https://cdn2.steamgriddb.com/icon/981ee11c08e460dc540242ee105b5ced/32/512x512.png) | ✔ |
| Halo Infinite | [Image link](https://www.tierragamer.com/wp-content/uploads/2020/07/halo-portada.jpg) | ❌ |
| Borderlands | [Image link](https://media.vandal.net/m/71969/borderlands-edicion-juego-del-ano-201943163663\_9.jpg) | ✔ |
| Borderlands: The Pre-Sequel | [Image link](https://www.gearboxsoftware.com/wp-content/uploads/2014/12/840070cd5a4f15581f6e1dcdedd5fa48c3f1abd7.png) | ✔ |
| Borderlands 2 | [Image link](https://s01.riotpixels.net/data/60/5c/605c09ad-01eb-4324-a2c9-82013d1f90c9.jpg/cover.borderlands-2.1024x1024.2014-04-24.24.jpg) | ✔ |
| COD: Advanced Warfare | [Image link](https://wepcgamer.com/wp-content/uploads/2021/10/Call-of-Duty-Ghosts-PC-Version-Full-Game-Setup-Free-Download.jpeg-1-1024x1024.webp) | ✔ |
| Call of Duty: WaW | [Image link](https://assets-prd.ignimgs.com/2022/03/28/codwaw-1648511549298.jpg) | ✔ |
| Call of Duty: World at War | [Image link](https://assets-prd.ignimgs.com/2022/03/28/codwaw-1648511549298.jpg) | ✔ |
| Call of Duty: Black Ops 4 | [Image link](https://assets1.ignimgs.com/2018/10/10/call-of-duty-black-ops-4---button-fin-1539211957163.jpg) | ✔ |
| Superliminal | [Image link](https://www.mobygames.com/images/covers/l/670660-superliminal-playstation-4-front-cover.jpg) | ✔ |
| YouTube | [Image link](https://upload.anarchyisland.gg/r/Youtube%20Icon.png?compress=false) | ✔ |
| Max | [Image link](https://assets-prd.ignimgs.com/2022/09/22/service-hbo-max-1663819764492.jpg) | ✔ |
| Blu-ray Player | [Image link](https://seeklogo.com/images/B/Blu-ray\_Disc-logo-7617B9FC8E-seeklogo.com.png) | ✔ |
| Spectrum TV | [Image link](https://pbs.twimg.com/media/FSghKvmXIAEjDMN.jpg) | ✔ |
| Crunchyroll | [Image link](https://assets-prd.ignimgs.com/2022/09/22/service-crunchyroll-1663819467267.jpg) | ✔ |
| Twitch | [Image link](https://is1-ssl.mzstatic.com/image/thumb/Purple116/v4/bc/bd/0b/bcbd0b7f-393a-e861-1540-c69794ad981a/TwitchAppIcon-0-1x\_U007emarketing-0-7-0-0-85-220-0.png/1024x1024.jpg) | ✔ |
| Hulu | [Image link](https://assets-prd.ignimgs.com/2022/09/22/service-hulu-1663828348772.jpg) | ✔ |
| Spotify Xbox - Music and Podcasts | [Image link](https://is1-ssl.mzstatic.com/image/thumb/Purple126/v4/1f/85/04/1f85048c-e420-06fb-ec42-a1048fd3506b/AppIcon-0-0-1x\_U007emarketing-0-6-0-0-85-220.png/1024x1024.jpg) | ✔ |
| VLC UWP | [Image link](https://images-eds-ssl.xboxlive.com/image?url=4rt9.lXDC4H\_93laV1\_eHHFT949fUipzkiFOBH3fAiZZUCdYojwUyX2aTonS1aIwMrx6NUIsHfUHSLzjGJFxxiJK\_HEPrjdesdyeQIKBd8CoiFrgY4r.ZkWqv.BA5Ada9hOspX.JXdTZc317jZzDuPJwizLoQfyhPuJ4J9LdU9k-&format=source) | ✔ |
| Microsoft Edge | [Image link](https://upload.wikimedia.org/wikipedia/commons/9/98/Microsoft\_Edge\_logo\_%282019%29.svg) | ❌ |
| VALORANT | [Image link](https://cdn2.steamgriddb.com/grid/af0aa72953e2c9642d7f8e305d917a52.png) | ✔ |
| Genshin Impact | [Image link](https://cdn2.steamgriddb.com/grid/42de707e3e52a0b8345bbc985af0060b.png) | ✔ |
| COD: Black Ops II | [Image link](http://s01.riotpixels.net/data/fd/25/fd25444d-d9a1-43b7-9a20-04644ee26432.jpg/cover.call-of-duty-black-ops-2.1024x1024.2014-04-24.133.jpg) | ✔ |
| Call of Duty: Black Ops | [Image link](https://assets-prd.ignimgs.com/2021/12/30/call-of-duty-black-ops-1-button-1640898530662.jpg) | ✔ |
| Battlefield 4 | [Image link](https://image.api.playstation.com/cdn/UP0006/CUSA00110\_00/VaulrBDwbGorU7Ykfjg5sNrJ5X9resKm.png) | ✔ |
| Portal: Still Alive | [Image link](https://static.pepper.pl/threads/raw/ob93V/664436\_1/re/1024x1024/qt/60/664436\_1.jpg) | ✔ |
| Portal 2 | [Image link](http://s01.riotpixels.net/data/b5/cf/b5cfe10d-7290-4bcb-a89d-e5d0e07b89f4.jpg/cover.portal-2.1024x1024.2014-04-24.1116.jpg) | ✔ |
| Xbox 360 Dashboard | [Image link](https://i.ibb.co/T8d9YQC/IMG-20210506-154930.png) | ✔ |
| Microsoft Store | [Image link](https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/i/bce61c2d-f08e-4cff-ab33-6360bdffd6e8/dekbb3k-48b3ab56-b50e-4752-99ee-5e5f849d605f.png) | ✔ |
| PDP Control Hub | [Image link](https://store-images.s-microsoft.com/image/apps.20790.14536315885801770.076b8775-9c74-4ce6-a4db-0a04d323096c.6ec01100-1fb8-4238-9c7e-052a05a5e6a6) | ❓ |
| COD: Black Ops III | [Image link](https://www.fayerwayer.com/resizer/c8Gerb7mPyaUHbRuaoQGp8MmBas=/1024x1024/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/metroworldnews/UEIX54ZOIRFL3KXN7LCM5TDRN4.jpg) | ✔ |
| Halo 5: Guardians | [Image link](https://i.blogs.es/2081f1/halo5\_keyart\_vert\_final/240\_240.jpg) | ❓ |
| PUBG: BATTLEGROUNDS | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202312/1402/ada609849edb9800c5d7edcbdb8d5d871a1122e0d0af57c1.png) | ✔ |
| Mass Effect | [Image link](https://cdn2.steamgriddb.com/grid/d5c237592a187a55a62436db1e1b1e61.png) | ✔ |
| Mass Effect 2 | [Image link](https://cdn2.steamgriddb.com/grid/08c795b843a9fdcadb684139ad586622.jpg) | ✔ |
| Mass Effect 3 | [Image link](https://cdn2.steamgriddb.com/grid/0d6d2c18339affad5ff919de35734236.png) | ✔ |
| Mass Effect: Andromeda | [Image link](https://cdn2.steamgriddb.com/grid/5b2d40deb3f6e982cd1f5d53790ea7ec.jpg) | ✔ |
| Mass Effect Legendary Edition | [Image link](https://cdn2.steamgriddb.com/grid/2ace71f2144ce59faec739e08603d4d3.jpg) | ✔ |
| LIMBO | [Image link](https://cdn2.steamgriddb.com/grid/91ae50d539e53a0c72eccd6ec1a55b66.jpg) | ✔ |
| INSIDE | [Image link](https://cdn2.steamgriddb.com/grid/51eac99551f4fa89da93f217a521f007.jpg) | ✔ |
| Firewatch | [Image link](https://cdn2.steamgriddb.com/grid/f3e34b1ad8a9a285039d400e6dfc86cc.jpg) | ✔ |
| Dying Light | [Image link](https://cdn2.steamgriddb.com/icon/c55ead078947051a856b1f3beb85f748/32/256x256.png) | ✔ |
| Minecraft: Xbox 360 Edition | [Image link](https://pm1.narvii.com/7967/cf7f89630b5ab843207ed4ae1b85bc49769fb02er1-1280-1280v2\_hq.jpg) | ✔ |
| Marvel's Guardians of the Galaxy | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202106/0215/Pw9cWnyqkix3EoCOGqrN1cgN.png) | ✔ |
| Assassin's Creed Valhalla | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202008/1318/8XGEPtD1xoasK0FYkYNcCn1z.png) | ✔ |
| Dante's Inferno | [Image link](https://ovallcorners.files.wordpress.com/2011/04/18-dantes-inferno.jpg) | ✔ |
| Call Of Duty: Modern Warfare 2 | [Image link](https://ellocodesebas.files.wordpress.com/2010/07/cod-mw2.jpg) | ❓ |
| World War Z | [Image link](https://image.api.playstation.com/cdn/EP2609/CUSA13930\_00/J9XHymEJeB00qNdIsGHO4PgizJJ7Gabi8VsmlJSYaUT3srBYDyH88Hulr7NkX4Vt.png?w=1024&thumb=false) | ✔ |
| Hellblade: Senua's Sacrifice | [Image link](https://media.vandal.net/m/25566/hellblade-senuas-sacrifice-201787132929\_6.jpg) | ✔ |
| FIFA 22 [XB1] | [Image link](https://image.api.playstation.com/vulcan/img/rnd/202111/0822/YiFF5Xkljek03HhUJa4gic1Y.png) | ✔ |
| Fall Guys | [Image link](https://cdn2.unrealengine.com/s10-logo-cropped-769x740-527f1dff6d3b.png?resize=1&w=920&quality=high[18:18]) | ❓ |
| Stumble Guys | [Image link](https://cdn2.steamgriddb.com/grid/eae7e6b10447faa61ded3859297594d5.png) | ✔ |
| Battlefield: Bad Company | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/thumb/a1323f274f0b46c069ea4ddd4fa56a76.jpg) | ✔ |
| Battlefield Bad Company 2 | [Image link](https://cdn2.steamgriddb.com/grid/535930dfb6b351001869d2cf9ee07833.jpg) | ✔ |
| Skyrim | [Image link](https://freesvg.org/img/skyrim.png) | ✔ |
| Conker: Live and Reloaded | [Image link](https://cdn2.steamgriddb.com/grid/596f6e834f2569ec81adc2fb6798f453.png) | ✔ |
| Forza Horizon | [Image link](https://static.wikia.nocookie.net/forzamotorsport/images/3/3d/FH1\_Boxart.jpg/revision/latest/top-crop/width/1024/height/1024) | ✔ |
| Forza Motorsport 3 | [Image link](https://vectorseek.com/wp-content/uploads/2023/07/Forza-Motorsport-3-Logo-Vector.jpg) | ✔ |
| Forza Motorsport 4 | [Image link](https://cdn2.steamgriddb.com/icon\_thumb/bc060de03aa94c7edf5e6b4f1755c1f0.png) | ✔ |
| Far Cry 5 | [Image link](https://image.api.playstation.com/cdn/UP0001/CUSA05904\_00/IKYAgcRh0k3IOklJSDoNBTk5t5MSm7KE.png) | ✔ |
| Netflix | [Image link](https://upload.wikimedia.org/wikipedia/commons/f/ff/Netflix-new-icon.png) | ✔ |
| Assassin's Creed Origins | [Image link](https://image.api.playstation.com/cdn/EP0001/CUSA05625\_00/6OhEbwPSI4Vy8AtS8PgP1jVxQLVvTmX7.png) | ✔ |
| Watch Dogs: Legion | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202007/0217/OX5mEmwgRPeSQrhGFU3n4moZ.png) | ✔ |
| Call of Duty: Vanguard | [Image link](https://media.vandal.net/m/105263/call-of-duty-vanguard-202111821165339\_1.jpg) | ✔ |
| Cyberpunk 2077 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202111/3013/cKZ4tKNFj9C00giTzYtH8PF1.png) | ✔ |
| Gears of War | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Gears1.png) | ✔ |
| Gears of War 2 | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Gears2.png) | ✔ |
| Gears of War 3 | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Gears3.png) | ❓ |
| Gears of War: Judgment | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Judgment.png) | ✔ |
| Gears of War: Ultimate Edition | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Ultimate%20Edition.png) | ✔ |
| Gears of War 4 | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Gears4.png) | ✔ |
| Gears 5 | [Image link](http://lmk.tdgalea.co.uk/share/Photography/Gaming/Box%20Art/Gears%20of%20War/Gears5.png) | ❓ |
| OMORI | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202206/1601/1agbi2hbB4vbYexXSqWm94jx.png) | ✔ |
| Warframe | [Image link](https://www.mobygames.com/images/covers/l/700400-warframe-playstation-5-front-cover.jpg) | ✔ |
| Modern Warfare | [Image link](https://assets-prd.ignimgs.com/2022/03/28/cod4-1648511386228.jpg) | ✔ |
| Modern Warfare 2 | [Image link](https://assets-prd.ignimgs.com/2022/09/24/codforcerecon-1664045338431.jpg) | ✔ |
| Modern Warfare 3 | [Image link](https://www.teahub.io/photos/full/122-1223188\_call-of-duty-modern-warfare.jpg) | ✔ |
| Alan Wake | [Image link](https://www.fayerwayer.com/resizer/Yt2iJrPyX\_DDbKee1DLMx6xd4gI=/1024x1024/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/metroworldnews/CK52GYCGURFHPP6FL2MURVNQNU.jpg) | ✔ |
| Kinect Adventures! | [Image link](https://assets-prd.ignimgs.com/2022/02/07/kinectadventures-sq1-1644265943035.jpg) | ✔ |
| Kinect Sports | [Image link](https://assets-prd.ignimgs.com/2022/02/07/kinectsports-sq-1644266059534.jpg) | ✔ |
| Kinect Sports: Season Two | [Image link](https://m.media-amazon.com/images/I/71ZleHj2UKL.jpg) | ❓ |
| NEED FOR SPEED MOST WANTED | [Image link](https://www.mobygames.com/images/covers/l/297365-need-for-speed-most-wanted-ps-vita-front-cover.jpg) | ✔ |
| Terraria – Xbox 360 Edition | [Image link](https://www.gamereactor.eu/media/28/terrariaparaxbox\_742841b.jpg) | ✔ |
| Call of Duty: Ghosts | [Image link](https://image.api.playstation.com/cdn/EP0002/CUSA00025\_00/IUeXkREOFg6l0BCgYUe4DxCSlryK8iPT.png) | ✔ |
| Dead Space 3 | [Image link](https://i.gadgets360cdn.com/products/large/460509-dead-space-3-ultimate-edition-playstation-3-front-cover-1000x1000-1656405233.jpeg) | ✔ |
| Diablo III | [Image link](https://www.zastavki.com/pictures/1024x1024/2013/\_Diablo\_III\_\_ever\_seen\_a\_devil\_045077\_31.jpg) | ✔ |
| Peggle 2 | [Image link](https://assets-prd.ignimgs.com/2022/03/18/peggle2-1647580639839.jpg) | ✔ |
| Trials Fusion | [Image link](https://assets-prd.ignimgs.com/2022/03/13/trialsfusion-1647197679497.jpg) | ✔ |
| A Plague Tale: Requiem | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202106/1717/xIQOO3Mo5YMnIm81qkH3y5kJ.png) | ✔ |
| Persona 5 Royal | [Image link](https://assets1.ignimgs.com/2020/02/14/persona-5-royal---button-fin-1581716582492.jpg) | ✔ |
| Tom Clancy's Rainbow Six Siege | [Image link](https://sm.ign.com/t/ign\_es/game/r/rainbow-si/rainbow-six-siege\_d2b2.1024.jpg) | ✔ |
| Tom Clancy's Rainbow Six Extraction | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202110/2613/dAX4bUiYtNYZRkK3TcOphTeO.png) | ✔ |
| ROBLOX | [Image link](https://assets-prd.ignimgs.com/2022/03/01/roblox-sq-1646155371025.jpg) | ✔ |
| TEKKEN TAG 2 | [Image link](https://assets-prd.ignimgs.com/2022/03/08/tekkentag2-1646766836349.jpg) | ✔ |
| TEKKEN TAG TOURNAMENT 2 | [Image link](https://assets-prd.ignimgs.com/2022/03/08/tekkentag2-1646766836349.jpg) | ✔ |
| TEKKEN 6 | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/0cbcc379a81888055b068e7cd194d786.png) | ✔ |
| Tekken 7 | [Image link](https://image.api.playstation.com/cdn/UP0700/CUSA05972\_00/4yfeeKKfJdD5WzDQsoiM3xrcqPlpDLm7.png) | ✔ |
| Hydro Thunder | [Image link](https://www.mobygames.com/images/covers/l/303536-hydro-thunder-hurricane-xbox-360-front-cover.png) | ❓ |
| NINJA GAIDEN 2 | [Image link](https://i.ibb.co/n7ZYM5H/NG2.png) | ✔ |
| Call of Duty: Modern Warfare II | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202205/2800/W5uSEsW7yefCNTHatS03v5q7.png) | ✔ |
| ZOE HD | [Image link](https://cdn2.steamgriddb.com/icon/8d297a658bd8918ca2428789005950df/32/256x256.png) | ✔ |
| Lost Odyssey | [Image link](https://assets-prd.ignimgs.com/2022/01/07/lost-odyssey-button-crop-1641596251636.jpg) | ✔ |
| Blue Dragon | [Image link](https://cdn2.steamgriddb.com/icon/96ecbfadac55a39b8909822f91399f00/32/64x64.png) | ❓ |
| Hi-Fi RUSH | [Image link](https://sm.ign.com/ign\_latam/cover/h/hi-fi-rush/hi-fi-rush\_43et.jpg) | ✔ |
| Persona 3 Portable | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/icon/f2e84d98d6dc0c7acd56b40509355666/32/256x256.png) | ✔ |
| Persona 4 Golden | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/icon\_thumb/ecb565cd82de68494c294dc8d4b419a0.png) | ✔ |
| Mortal Shell: Enhanced Edition | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/icon/17b65afe58c49edc1bdd812c554ee3bb/32/256x256.png) | ✔ |
| Monster Hunter Rise | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/icon/faa453efde4ac6a36849ba381feb9e87/32/256x256.png) | ✔ |
| Doom Eternal | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202010/0114/ERNPc4gFqeRDG1tYQIfOKQtM.png) | ✔ |
| Atomic Hearth | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202209/2815/SSru3b0CYWviMXfW6bYgaWlX.png) | ✔ |
| FIFA 23 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202301/0312/TwxvAAWgqCrFC3y73VPZUS7m.png) | ✔ |
| Destiny 2 | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/thumb/dbd70841dd7997b1af1fa9ac1f4cf969.jpg) | ✔ |
| Call of Duty: Infinite Warfare | [Image link](https://image.api.playstation.com/cdn/EP0002/CUSA05282\_00/JhIXa8se54KKNhggEahiO0Oz78IITOGF.png) | ✔ |
| DEAD OR ALIVE 1 Ultimate | [Image link](https://i.imgur.com/WA3VPTS.png) | ✔ |
| DEAD OR ALIVE 2 Ultimate | [Image link](https://i.imgur.com/CJKFobH.png) | ✔ |
| Dead or Alive 3 | [Image link](https://assets-prd.ignimgs.com/2022/05/04/doa3-1651685752417.jpg) | ✔ |
| DEAD OR ALIVE 4 | [Image link](https://assets-prd.ignimgs.com/2022/11/25/doa4-1669406347926.jpg) | ✔ |
| DEAD OR ALIVE 5 Last Round: Core Fighters | [Image link](https://image.api.playstation.com/cdn/UP4108/CUSA01627\_00/8b3eVINuTJf6y47a98THfkEtiuB1zs0u.png) | ✔ |
| DEAD OR ALIVE 6: Core Fighters | [Image link](https://image.api.playstation.com/cdn/UP4108/CUSA12152\_00/suTiUywgfKg7QS6lnU497q1W98KWbIae.png) | ✔ |
| Left 4 Dead | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/c97223bc53a281ac2baafc64908e824b.png) | ✔ |
| Left 4 Dead 2 | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/5ec59bc90d6605a2c1c6af6d997ea344.png) | ✔ |
| The Orange Box | [Image link](https://static-pepper.dealabs.com/threads/raw/CsIXi/2525718\_1/re/1024x1024/qt/60/2525718\_1.jpg) | ✔ |
| Saints Row | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/e22e151b3e1b1e5693bac710f9ad81b8.png) | ✔ |
| Saints Row 2 | [Image link](https://assets-prd.ignimgs.com/2022/01/07/saints-row-2-button-1641597906385.jpg) | ✔ |
| Saints Row: The Third | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/3ff73960b627328f420342541cf4fa68.png) | ✔ |
| Saints Row: The Third Remastered | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202105/1110/OwxZcWTSQshQNCS8n3M1dm25.png) | ✔ |
| Saints Row IV | [Image link](https://i.ebayimg.com/images/g/EW4AAOSwj51jNWUe/s-l1600.jpg) | ✔ |
| Saints Row IV: Re-Elected | [Image link](https://image.api.playstation.com/cdn/UP2047/CUSA01164\_00/nhM6vndQ0hzEwA6FKh99Kjq9ILNaQ8tm.png) | ✔ |
| Saints Row: Gat out of Hell | [Image link](https://assets-prd.ignimgs.com/2022/01/07/saints-row-iv-gat-out-of-hell-button-1641598025730.jpg) | ✔ |
| ULTRA STREETFIGHTER IV | [Image link](https://image.api.playstation.com/cdn/UP9012/CUSA01846\_00/bfVn55KvgbaZp7GKHm6VkNoq6EiHqFjF.png) | ✔ |
| SUPER STREETFIGHTER IV ARCADE EDITION | [Image link](https://images.stopgame.ru/games/logos/12365/super\_street\_fighter\_4\_arcade\_edition-square.jpg) | ✔ |
| STREET FIGHTER IV | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/dd32d86c8120238307307260fe0d81bd.png) | ✔ |
| Street Fighter 6 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202211/1407/XFU0aPBvtm3W2od1ZvhByAOv.png) | ✔ |
| Catherine | [Image link](https://assets1.ignimgs.com/2019/01/10/catherine---button-1547161850707.jpg) | ✔ |
| Call of Duty: Modern Warfare Remastered | [Image link](https://image.api.playstation.com/cdn/UP0002/CUSA03522\_00/t7SHaSjuUXFZ3VHl6U4FuSFrDMtkOIyP.png) | ✔ |
| Cuphead | [Image link](https://miro.medium.com/v2/resize:fit:1400/0\*H9w4geSiKvbM3GM2.png) | ✔ |
| Killer Instinct | [Image link](https://games-b26f.kxcdn.com/wp-content/uploads/2016/12/killer-instinct-1024x1024.jpg) | ✔ |
| Rare Replay | [Image link](https://assets-prd.ignimgs.com/2022/03/14/rarereplay-1647222210920.jpg) | ✔ |
| SONIC UNLEASHED | [Image link](https://assets-prd.ignimgs.com/2022/01/21/image-sonic-1-1642735809327.jpg) | ✔ |
| Counter-Strike: GO | [Image link](https://assets-prd.ignimgs.com/2021/12/30/counter-strike-global-offensive-button-1640896165989.jpg) | ✔ |
| Shadows of the Damned | [Image link](https://assets-prd.ignimgs.com/2022/04/17/sotd51-1650159532451.jpg) | ✔ |
| LOLLIPOP CHAINSAW | [Image link](https://assets-prd.ignimgs.com/2022/04/22/lollipopchainsaw-1650671944003.jpg) | ✔ |
| Disney+ | [Image link](https://assets-prd.ignimgs.com/2022/09/22/service-disney-plus-1663831239344.jpg) | ✔ |
| Prime Video | [Image link](https://play-lh.googleusercontent.com/VojafVZNddI6JvdDGWFrRmxc-prrcInL2AuBymsqGoeXjT4f9sv7KnetB-v3iLxk\_Koi) | ✔ |
| Amazon Instant Video | [Image link](https://play-lh.googleusercontent.com/VojafVZNddI6JvdDGWFrRmxc-prrcInL2AuBymsqGoeXjT4f9sv7KnetB-v3iLxk\_Koi) | ✔ |
| Xbox Avatar Editor | [Image link](https://store-images.s-microsoft.com/image/apps.16141.13510798887611042.610ae026-cc3d-4b4e-9044-1b8721988d93.c281cd26-66dc-4ed3-a811-c0fe1217ed11) | ✔ |
| Xbox Original Avatars | [Image link](https://static.wikia.nocookie.net/xbox/images/e/e4/Xbox\_Original\_Avatars\_App\_Icon.png/revision/latest?cb=20220603100736) | ✔ |
| Ubisoft Club | [Image link](https://cdn2.steamgriddb.com/icon/bf31cf91a25a954107b264332a7ca548/32/512x512.png) | ✔ |
| Ubisoft Connect | [Image link](https://cdn2.steamgriddb.com/icon/bf31cf91a25a954107b264332a7ca548/32/512x512.png) | ✔ |
| Rocket League | [Image link](https://upload.wikimedia.org/wikipedia/commons/e/e0/Rocket\_League\_coverart.jpg) | ✔ |
| Skate 3 | [Image link](https://store-images.s-microsoft.com/image/apps.18720.68005754082254855.39795a60-73cf-4461-87d9-7f112c30c43c.46888afa-996b-4016-b5b4-c2e0b78171e2?q=90&w=177&h=265) | ❓ |
| Minecraft Dungeons | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/a9f2861cf82efebf18f83d9ce721a576.png) | ✔ |
| Minecraft Legends | [Image link](https://tinfoil.media/ti/01007C6012CC8000/0/0/) | ✔ |
| Tetris Effect: Connected | [Image link](https://image.api.playstation.com/vulcan/img/rnd/202108/0922/btyvYPfAuS53lkGbeK8ZaWzN.png) | ✔ |
| Stardew Valley | [Image link](https://image.api.playstation.com/cdn/UP2456/CUSA06840\_00/0WuZecPtRr7aEsQPv2nJqiPa2ZvDOpYm.png) | ✔ |
| Rust | [Image link](https://upload.anarchyisland.gg/r/Rust%20Icon.png?compress=false) | ✔ |
| Rust Console Edition - Public Test Branch | [Image link](https://upload.anarchyisland.gg/r/Rust%20PTB%20Icon.png?compress=false) | ✔ |
| Among Us | [Image link](https://image.api.playstation.com/vulcan/img/rnd/202107/0115/D5IIJwm65MLMPENwWzzO7rjd.png) | ✔ |
| Dead by Daylight: Special Edition | [Image link](https://upload.anarchyisland.gg/r/DBD%20Icon.png?compress=false) | ✔ |
| Battlefield 2042 Xbox Series X\|S | [Image link](https://upload.anarchyisland.gg/r/Battlefield%202042%20Icon.png?compress=false) | ✔ |
| Overwatch 2 | [Image link](https://upload.anarchyisland.gg/r/Overwatch%202%20Icon.png?compress=false) | ✔ |
| Sea of Thieves 2023 Edition | [Image link](https://upload.anarchyisland.gg/r/SoT%20Icon.jpeg?compress=false) | ✔ |
| Redfall | [Image link](https://upload.anarchyisland.gg/r/Redfall%20Icon.jpg?compress=false) | ✔ |
| Red Dead Redemption 2 | [Image link](https://upload.anarchyisland.gg/r/RDR%202%20Icon.jpeg?compress=false) | ✔ |
| Insurgency: Sandstorm | [Image link](https://upload.anarchyisland.gg/r/Insurgency%20Sandstorm%20Icon.png?compress=false) | ✔ |
| Atomic Heart | [Image link](https://upload.anarchyisland.gg/r/Atomic%20Heart%20Icon.png?compress=false) | ✔ |
| Rock Band 4 | [Image link](https://image.api.playstation.com/cdn/UP8802/CUSA02084\_00/FmVyycG5ukypLJz9iUYdBVtkI9H8axtx.png) | ✔ |
| SUPERBEAT: XONiC | [Image link](https://assets-prd.ignimgs.com/2022/07/09/xionic-1657391403495.jpg) | ✔ |
| ŌKAMI HD | [Image link](https://image.api.playstation.com/cdn/UP0102/CUSA08418\_00/bKaklXPelfDeAe4ODKN25A63ZqOMMlhi.png) | ✔ |
| Friday the 13th: The Game | [Image link](https://upload.anarchyisland.gg/r/Friday%20the%2013th%20The%20Game%20Icon.png?compress=false) | ✔ |
| Call of Duty: Modern Warfare II | [Image link](https://cdn.kulturegeek.fr/wp-content/uploads/2022/05/Call-of-Duty-Modern-Warfare-2-2022-1-1024x1024.jpg) | ✔ |
| Call of Duty: Modern Warfare III | [Image link](https://cdn2.steamgriddb.com/grid/f4d00a10a3b2a52d7ea6610567f1f1b8.png) | ✔ |
| Call of Duty | [Image link](https://cdn2.steamgriddb.com/grid/89b80ed33585794394cb0133dfa5f112.png) | ✔ |
| EA SPORTS FIFA 23 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202301/0312/TwxvAAWgqCrFC3y73VPZUS7m.png) | ✔ |
| XDefiant Open Session | [Image link](https://upload.anarchyisland.gg/r/XDefiant%20Icon.jpg?compress=false) | ❓ |
| XDefiant | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202409/2314/39efe76491a3e1a104080dffcd3d1e7ef46d7fc4265415d8.png) | ✔ |
| Pure | [Image link](http://store-images.s-microsoft.com/image/apps.56982.71138214337886029.cf245fbf-37ba-4659-949b-e9f708980113.0d650d85-7dd6-4f17-8b23-3a68b57ecce3) | ✔ |
| Saints Row: The Third | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/3ff73960b627328f420342541cf4fa68.png) | ✔ |
| Battlefield 3 | [Image link](https://assets-prd.ignimgs.com/2021/12/21/battlefield-3-button-fin-1640126554216.jpg) | ✔ |
| LEGO Indiana Jones | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/38358bac3cc2848d2dfb10d268e7e252.png) | ✔ |
| LEGO Batman | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/1117aae5998932ffa2f9fdda31dbcd2d.png) | ✔ |
| DAYTONA USA | [Image link](https://media.vgm.io/releases/44/11744/11744-1596288334.jpg) | ✔ |
| The Texas Chain Saw Massacre | [Image link](https://upload.anarchyisland.gg/r/TCM%20Icon.png?compress=false) | ✔ |
| The Texas Chain Saw Massacre - PC Edition | [Image link](https://upload.anarchyisland.gg/r/LqzUi1.png?compress=false) | ✔ |
| Crackdown 2 | [Image link](https://assets-prd.ignimgs.com/2022/02/26/crackdown2-sq-1645908598382.jpg) | ✔ |
| Home | [Image link](one\_dashboard) | ✔ |
| FIFA 23 [XB1] | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202301/0312/TwxvAAWgqCrFC3y73VPZUS7m.png) | ✔ |
| Red Dead Redemption | [Image link](https://cdn2.steamgriddb.com/file/sgdb-cdn/grid/38c0cbe22bf9f9a5627b511f107d0300.png) | ✔ |
| Starfield | [Image link](https://upload.anarchyisland.gg/r/Starfield%20Icon.jpg?compress=false) | ✔ |
| Payday 3 | [Image link](https://upload.anarchyisland.gg/r/Payday3%20Icon.jpg?compress=false) | ✔ |
| Plants vs. Zombies Garden Warfare | [Image link](https://i.ibb.co/9Y8ZQsv/icon.png) | ✔ |
| Need for Speed Hot Pursuit Remastered | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202210/3122/AooxHg4WoMdhe8oPQYn3XdrG.png) | ✔ |
| Batman: Arkham Knight | [Image link](https://image.api.playstation.com/cdn/UP1018/CUSA00133\_00/due3Vp0T2VSGfBtGsWjVnrL4o882iYVk.png) | ✔ |
| DOOM | [Image link](https://acdn.mitiendanube.com/stores/002/602/523/products/whatsapp-image-2022-10-16-at-20-08-08-11-d909d35abb06f618f116709515330366-1024-1024.jpeg) | ✔ |
| Devil May Cry 5 | [Image link](https://assets1.ignimgs.com/2019/03/04/devil-may-cry-5---button-fin-1551739966394.jpg) | ✔ |
| DRAGON BALL XENOVERSE | [Image link](https://cdn2.steamgriddb.com/grid/ed645df163c420c0f2ae8b51a29dab6b.png) | ✔ |
| Mirror's Edge Catalyst | [Image link](https://image.api.playstation.com/cdn/EP0006/CUSA01499\_00/BlmZA1q0foctr8IIDE6LcSXiuYnWtSGS.png) | ✔ |
| eFootball 2024 | [Image link](https://image.api.playstation.com/vulcan/ap/rnd/202311/0206/64c52a51a6c017c6d8600d1cc5e52d6780dedc905b1ee5ab.png) | ✔ |
| WATCH\_DOGS | [Image link](https://assets-prd.ignimgs.com/2022/01/05/watch-dogs-1-button-1641369103832.jpg) | ✔ |
| War Thunder | [Image link](https://upload.anarchyisland.gg/r/War%20Thunder%20Icon.jpg?compress=false) | ✔ |
| Persona 3 Reload | [Image link](https://cdn2.steamgriddb.com/icon/d0017ee0d9e6a1f9f9bb7e7fb649fe18.png) | ✔ |
| Train Sim World 4 | [Image link](https://upload.anarchyisland.gg/r/TSW4%20Icon.jpg?compress=false) | ✔ |
| Dead Island 2 | [Image link](https://upload.anarchyisland.gg/r/Dead%20Island%202%20Icon.jpg?compress=false) | ✔ |
| Palworld (Game Preview) | [Image link](https://upload.anarchyisland.gg/r/Palworld%20Icon.jpg?compress=false) | ✔ |
| Dead by Daylight | [Image link](https://upload.anarchyisland.gg/r/DBD%20Icon.png?compress=false) | ✔ |

### Symbols:
✔: Icon is working.

❓: Icon is either low-res or not a square.

❌: Icon is not working.
