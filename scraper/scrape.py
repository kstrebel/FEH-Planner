from distutils.filelist import findall
from logging import exception
from plistlib import UID
from bs4 import BeautifulSoup
import requests
import json
import re


def main():
    page = ""

    try:
        pagex = open(
            "feh-scraper\pages\Abel_ The Panther - Fire Emblem Heroes Wiki.html",
            encoding="utf8",
        )
        page = requests.get("https://feheroes.fandom.com/wiki/Caeda:_Sea-Blossom_Pair")
    except Exception as ex:
        print(ex)
    else:
        soup = BeautifulSoup(page.text, "html.parser")
        # soup = BeautifulSoup(pagex, "html.parser")
        unitInfo = soup.find(class_="wikitable hero-infobox")

        u_id = dataAfterTh(unitInfo, "Internal ID")
        u_id = u_id[u_id.find("(") + 1 : u_id.find(")")] or ""

        u_name = unitInfo.find(style="font-size:160%;").get_text() or ""
        u_epithet = unitInfo.find(style="font-size:90%").get_text() or ""
        u_imageAddress = ""  # ignoring this for now

        entries = getEntries(unitInfo)
        u_entry1 = entries[0].get_text() or ""
        u_entry2 = entries[1].get_text() or ""

        u_movement = dataAfterTh(unitInfo, "Move Type") or ""
        u_weapon = dataAfterTh(unitInfo, "Weapon Type") or ""
        u_special = getSpecialType(unitInfo, soup) or ""
        u_availability = ""
        u_rarity = ""

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


def getSpecialType(table, page):
    if table.find("th", string=re.compile("Duo")):
        return "Duo"
    elif table.find("th", string=re.compile("Harmonized")):
        return "Harmonized"
    elif "Legendary" in dataAfterTh(table, "Rarities"):
        return "Legendary"
    elif "Mythic" in dataAfterTh(table, "Rarities"):
        return "Mythic"
    else:
        unitCategories = page.find("ul", "wds-list wds-is-linked")
        if (
            unitCategories != None
            and unitCategories.find("li").get_text("Ascended Heroes") != None
        ):
            print(unitCategories.find("li").get_text("Ascended Heroes"))
            return "Ascended"
        else:
            return ""


def getEntries(table):
    element = table.find("span", string=re.compile("Entry")).parent.find_next_sibling(
        "td"
    )

    entries = element.find_all("i")

    if len(entries) < 2:
        entries = [entries[0], BeautifulSoup("<a></a>", "html.parser")]

    # print()
    # print()
    # print()
    # #print(entries)
    # print(entries[0].get_text())
    # print(entries[1].get_text())

    return entries


def dataAfterTh(table, header):
    element = table.find("th", string=re.compile(header))

    if element == None:
        element = table.find(
            "span", string=re.compile(header)
        ).parent.find_next_sibling("td")
    else:
        element = element.find_next_sibling("td")

    # print()
    # print()
    # print()
    # print(element.get_text("|", strip=True))
    return element.get_text("|", strip=True)


if __name__ == "__main__":
    main()
