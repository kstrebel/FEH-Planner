from distutils.filelist import findall
from logging import exception
from plistlib import UID
from bs4 import BeautifulSoup
import requests
import json
import re


def main():
    # page = ""
    page = """<table class="wikitable hero-infobox">
<tbody><tr>
<th colspan="2" style="padding:1em;background-color:var(--th-color1,#408bca)"><span style="font-size:160%;">Abel</span><br><span style="font-size:90%">The Panther</span>
</th></tr>
<tr>
<td colspan="2" style="text-align:center;"><div class="oo-ui-layout oo-ui-panelLayout oo-ui-panelLayout-framed"><div class="oo-ui-layout oo-ui-menuLayout oo-ui-menuLayout-static oo-ui-menuLayout-top oo-ui-menuLayout-showMenu oo-ui-indexLayout"><div class="oo-ui-menuLayout-menu" aria-hidden="false"><div class="oo-ui-layout oo-ui-panelLayout oo-ui-indexLayout-tabPanel"><div class="oo-ui-widget oo-ui-widget-enabled oo-ui-selectWidget oo-ui-selectWidget-unpressed oo-ui-selectWidget-depressed oo-ui-tabSelectWidget" aria-disabled="false" role="tablist" tabindex="0" aria-activedescendant="ooui-1"><div class="oo-ui-widget oo-ui-widget-enabled oo-ui-optionWidget oo-ui-tabOptionWidget oo-ui-labelElement oo-ui-optionWidget-selected" aria-disabled="false" aria-selected="true" tabindex="-1" role="tab" id="ooui-1" aria-controls="ooui-2"><span class="oo-ui-labelElement-label">Portrait</span></div><div class="oo-ui-widget oo-ui-widget-enabled oo-ui-optionWidget oo-ui-tabOptionWidget oo-ui-labelElement" aria-disabled="false" aria-selected="false" tabindex="-1" role="tab" id="ooui-3" aria-controls="ooui-4"><span class="oo-ui-labelElement-label">Attack</span></div><div class="oo-ui-widget oo-ui-widget-enabled oo-ui-optionWidget oo-ui-tabOptionWidget oo-ui-labelElement" aria-disabled="false" aria-selected="false" tabindex="-1" role="tab" id="ooui-5" aria-controls="ooui-6"><span class="oo-ui-labelElement-label">Special</span></div><div class="oo-ui-widget oo-ui-widget-enabled oo-ui-optionWidget oo-ui-tabOptionWidget oo-ui-labelElement" aria-disabled="false" aria-selected="false" tabindex="-1" role="tab" id="ooui-7" aria-controls="ooui-8"><span class="oo-ui-labelElement-label">Damage</span></div></div></div></div><div class="oo-ui-menuLayout-content"><div class="oo-ui-layout oo-ui-panelLayout oo-ui-stackLayout oo-ui-indexLayout-stackLayout"><div class="oo-ui-layout oo-ui-panelLayout oo-ui-panelLayout-scrollable oo-ui-tabPanelLayout oo-ui-tabPanelLayout-active" role="tabpanel" aria-labelledby="ooui-1" id="ooui-2"><a href="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/c/cd/Abel_The_Panther_Face.webp/revision/latest?cb=20190920195426" class="image"><img alt="Abel The Panther Face.webp" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/c/cd/Abel_The_Panther_Face.webp/revision/latest/scale-to-width-down/340?cb=20190920195426" decoding="async" width="340" height="408" data-image-name="Abel The Panther Face.webp" data-image-key="Abel_The_Panther_Face.webp"></a></div><div class="oo-ui-layout oo-ui-panelLayout oo-ui-panelLayout-scrollable oo-ui-tabPanelLayout oo-ui-element-hidden" role="tabpanel" aria-labelledby="ooui-3" id="ooui-4" aria-hidden="true"><a href="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/2/2f/Abel_The_Panther_BtlFace.webp/revision/latest?cb=20190920195430" class="image"><img alt="Abel The Panther BtlFace.webp" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/2/2f/Abel_The_Panther_BtlFace.webp/revision/latest/scale-to-width-down/340?cb=20190920195430" decoding="async" width="340" height="388" data-image-name="Abel The Panther BtlFace.webp" data-image-key="Abel_The_Panther_BtlFace.webp"></a></div><div class="oo-ui-layout oo-ui-panelLayout oo-ui-panelLayout-scrollable oo-ui-tabPanelLayout oo-ui-element-hidden" role="tabpanel" aria-labelledby="ooui-5" id="ooui-6" aria-hidden="true"><a href="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/0/0b/Abel_The_Panther_BtlFace_C.webp/revision/latest?cb=20190920195435" class="image"><img alt="Abel The Panther BtlFace C.webp" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/0/0b/Abel_The_Panther_BtlFace_C.webp/revision/latest/scale-to-width-down/340?cb=20190920195435" decoding="async" width="340" height="388" data-image-name="Abel The Panther BtlFace C.webp" data-image-key="Abel_The_Panther_BtlFace_C.webp"></a></div><div class="oo-ui-layout oo-ui-panelLayout oo-ui-panelLayout-scrollable oo-ui-tabPanelLayout oo-ui-element-hidden" role="tabpanel" aria-labelledby="ooui-7" id="ooui-8" aria-hidden="true"><a href="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/2/28/Abel_The_Panther_BtlFace_D.webp/revision/latest?cb=20190920195439" class="image"><img alt="Abel The Panther BtlFace D.webp" src="data:image/gif;base64,R0lGODlhAQABAIABAAAAAP///yH5BAEAAAEALAAAAAABAAEAQAICTAEAOw%3D%3D" decoding="async" width="340" height="388" data-image-name="Abel The Panther BtlFace D.webp" data-image-key="Abel_The_Panther_BtlFace_D.webp" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/2/28/Abel_The_Panther_BtlFace_D.webp/revision/latest/scale-to-width-down/340?cb=20190920195439" class="lazyload"></a></div></div></div></div></div><span style="font-size:85%"><i>Art by: <a href="/wiki/Sasashima_Suisei" title="Sasashima Suisei">Sasashima Suisei (笹島彗星)</a></i></span>
</td></tr>
<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Description
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;">Altean cavalier known for his sensibility. Rode with Cain in service of Marth. Appears in Fire Emblem: Mystery of the Emblem.
</td></tr>
<tr>
<th style="width:10em;background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;"><span title="Represents the rarities at which the hero can be summoned or rewarded. All heroes can eventually reach 5★ rarity regardless of summoning rarities." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Rarities</span>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;">3<img alt="★" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/b/b4/Icon_Rarity_3.png/revision/latest/scale-to-width-down/20?cb=20180513213520" decoding="async" width="20" height="20" data-image-name="Icon Rarity 3.png" data-image-key="Icon_Rarity_3.png" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/b/b4/Icon_Rarity_3.png/revision/latest/scale-to-width-down/20?cb=20180513213520" class=" lazyloaded">&nbsp;–&nbsp;4<img alt="★" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/7/7d/Icon_Rarity_4.png/revision/latest/scale-to-width-down/20?cb=20180513213504" decoding="async" width="20" height="20" data-image-name="Icon Rarity 4.png" data-image-key="Icon_Rarity_4.png" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/7/7d/Icon_Rarity_4.png/revision/latest/scale-to-width-down/20?cb=20180513213504" class=" lazyloaded">
</td></tr>












<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Weapon Type
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><img alt="" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/6/60/Icon_Class_Blue_Lance.png/revision/latest/scale-to-width-down/19?cb=20181024054843" decoding="async" width="19" height="20" data-image-name="Icon Class Blue Lance.png" data-image-key="Icon_Class_Blue_Lance.png" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/6/60/Icon_Class_Blue_Lance.png/revision/latest/scale-to-width-down/19?cb=20181024054843" class=" lazyloaded">&nbsp;<a href="/wiki/Lance" title="Lance"><span title="Lance. Physical weapon. Range: 1. Damage reduced by target's Def." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Lance</span></a>
</td></tr>
<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Move Type
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><img alt="Icon Move Cavalry.png" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/9/9f/Icon_Move_Cavalry.png/revision/latest/scale-to-width-down/20?cb=20180513212041" decoding="async" width="20" height="20" data-image-name="Icon Move Cavalry.png" data-image-key="Icon_Move_Cavalry.png" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/9/9f/Icon_Move_Cavalry.png/revision/latest/scale-to-width-down/20?cb=20180513212041" class=" lazyloaded">&nbsp;<a href="/wiki/Cavalry" title="Cavalry"><span title="Cavalry unit. Can move three spaces. Cannot move through forests." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Cavalry</span></a>
</td></tr>
<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Voice Actor <sup>EN</sup>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><a href="/wiki/Mick_Wingert" title="Mick Wingert">Mick Wingert</a>
</td></tr>


<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Voice Actor <sup>JP</sup>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><a href="/wiki/Satou_Takuya" title="Satou Takuya">Satou Takuya (佐藤拓也)</a>
</td></tr>
<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;"><span title="The date the Hero was first made obtainable." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Release Date</span>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><time datetime="2017-02-02">2017-02-02</time>
</td></tr>



<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;"><span title="As shown on the Hero filter menu, and used in places like Limited Hero Battles." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Entry</span>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><img alt="Icon MiniUnit Head 1.png" src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/1/12/Icon_MiniUnit_Head_1.png/revision/latest/scale-to-width-down/21?cb=20200531064315" decoding="async" width="21" height="20" data-image-name="Icon MiniUnit Head 1.png" data-image-key="Icon_MiniUnit_Head_1.png" data-src="https://static.wikia.nocookie.net/feheroes_gamepedia_en/images/1/12/Icon_MiniUnit_Head_1.png/revision/latest/scale-to-width-down/21?cb=20200531064315" class=" lazyloaded">&nbsp;<i><a href="/wiki/Fire_Emblem:_Shadow_Dragon_and_the_Blade_of_Light" title="Fire Emblem: Shadow Dragon and the Blade of Light">Shadow Dragon</a> / (<a href="/wiki/Fire_Emblem:_New_Mystery_of_the_Emblem" title="Fire Emblem: New Mystery of the Emblem">New</a>) <a href="/wiki/Fire_Emblem:_Mystery_of_the_Emblem" title="Fire Emblem: Mystery of the Emblem">Mystery</a></i>
</td></tr>

<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;">Internal ID
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;"><code>PID_アベル</code> (37)
</td></tr>



<tr>
<th style="background-color:unset !important;border:none;color:unset;text-shadow:none;text-align:right;vertical-align:top;"><span title="The values used for 'Origin' for barracks and Catalog of Heroes. For more information, see the Catalog of Heroes page." style="border-bottom:0;text-decoration:underline dotted;cursor:help;">Origin</span>
</th>
<td style="border:unset;border-left:2px var(--th-color1) solid;">10000100700
</td></tr></tbody></table>"""

    try:
        # page = requests.get("https://feheroes.fandom.com/wiki/Abel:_The_Panther")
        x = 0
    except Exception as ex:
        print(ex)
    else:
        # soup = BeautifulSoup(page.text, "html.parser")
        soup = BeautifulSoup(pagex, "html.parser")
        unitInfo = soup.find(class_="wikitable hero-infobox")

        u_id = dataAfterTh(unitInfo, "Internal ID")
        u_id = u_id[u_id.find("(") + 1 : u_id.find(")")] or ""

        u_name = unitInfo.find(style="font-size:160%;").get_text() or ""
        u_epithet = unitInfo.find(style="font-size:90%").get_text() or ""
        u_imageAddress = "" #ignoring this for now

        entries=getEntries(unitInfo)
        u_entry1 = entries[0].get_text() or ""
        u_entry2 = entries[1].get_text() or ""
        
        u_movement = ""
        u_weapon = ""
        u_special = ""
        u_availability = ""
        u_rarity = ""

        # hello = unitInfo.find("th", string=re.compile("Internal ID")).find_next_sibling(
        #     "td"
        # )
        # aaa = hello.getText("|", strip=True)

        unit = {
            "UnitID": u_id,
            "Name": u_name,
            "Epithet": u_epithet,
            "Image": u_imageAddress,
            "Entry1": u_entry1,
            "Entry2": u_entry2,
            "MovementType": u_movement,
            "WeaponType": u_weapon,
            "SpecialType": u_special,
            "Availability": u_availability,
            "LowestRarity": u_rarity,
        }

        print(json.dumps(unit, indent=4))

    return 0


def getEntries(table):
    element=table.find("span", string=re.compile("Entry")).parent.find_next_sibling("td")

    entries=element.find_all("i")

    if len(entries)<2:
        entries=[entries[0], BeautifulSoup("<a></a>", "html.parser")]

    # print()
    # print()
    # print()
    # #print(entries)
    # print(entries[0].get_text())
    # print(entries[1].get_text())
    
    return entries

def dataAfterTh(table, header):
    element = table.find("th", string=re.compile(header))

    if element==None:
        element=table.find("span", string=re.compile(header)).parent.find_next_sibling("td")
    else:
        element=element.find_next_sibling("td")

    # print()
    # print()
    # print()
    # print(element.get_text("|", strip=True))
    return element.get_text("|", strip=True)


if __name__ == "__main__":
    main()
