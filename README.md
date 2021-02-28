# Configurable-Harvest
BepInEx plugin for Valheim. Enables configurable drop tables for resource nodes

# Install
Drop the DLL file from the release into the BepInEx plugins folder. You will of course need to have BepInEx for Valheim installed.

# Build
You will need to re-add the referenced DLLs. They are all included with BepInEx.

# How Drop Tables work

In Valheim drop tables are basically lists of items that a resource or monster can drop upon destruction/death.

When a drop table is activated, the game will roll a number of RNG dice to determine which item from the list is dropped.
Each item in the list has a weight, that determines it's likelyhood of dropping. Higher weights means more likely to drop.
A drop table can be activated more than once for the same destruction event, determined by the drop table's DropMin and DropMax
properties.

A drop table can also be set to drop one of each item on it's list. This only works if the DropMin and DropMax properties of the drop table
match the number of entries in the list. If a drop table has 3 items in it's list, and DropMin=1 and DropMax=1, it will only drop the item
with the highest weight.

Entries in the drop table have a **Weight**, **StackMin** and **StackMax** properties. The weight determines how likely this entry is to drop
among all the entries. Higher weight means more likely. The StackMin and StackMax determines the stack size of the item dropped.

# Configure
Find the configuration file (dk.mft_dev.configurable_harvest.cfg) in BepInEx's config folder.

Each resource node type has it's own section.
Generally they consist of a drop table definition and a number of entries

The configuration mirrors the game's own definition of a drop table.

# Drop Tables

- Enabled: Enables the changes for the drop table. If this is false, no changes will be applied
- DropChance: Factor ranging from 0 to 1. Determines the chance of the resource node to drop anything.
- DropTable OneOfEach: Determines whether the drop table should drop one of each item in the list, or use RNG to determine drops
- DropTable DropMin: Minimum number of times the drop table is activated
- DropTable DropMax: Maximum number of times the drop table is activated

- DropTable <ItemName> Weight: The weight this item has in the RNG decision
- DropTable <ItemName> Min: Minimum stack size if the item is dropped
- DropTable <ItemName> Max: Maximum stack size if the item is dropped

# Example

The below values will cause Muddy Scrap Piles to drop one of each item in the list (Iron Scrap, Withered Bone and Leather Scraps)
```
[Iron]
Enabled = true
DropChance = 1
DropTable OneOfEach = true
DropTable DropMin = 3
DropTable DropMax = 3

DropTable IronScrap Weight = 5
DropTable IronScrap Min = 1
DropTable IronScrap Max = 1

DropTable WitheredBone Weight = 1
DropTable WitheredBone Min = 1
DropTable WitheredBone Max = 1

DropTable LeatherScraps Weight = 1
DropTable LeatherScraps Min = 1
DropTable LeatherScraps Max = 1
```

The configuration below would cause Muddy Scrap Piles to roll RNG 3 times to determine drops.
Iron Scrap would have a 5/7 chance of dropping, with a stack size of 1 to 3.
Withered Bon would have a 1/7 chance of dropping a single item
Leather Scraps would also have 1/7 chance of dropping a single item


```
[Iron]
Enabled = true
DropChance = 1
DropTable OneOfEach = false
DropTable DropMin = 3
DropTable DropMax = 3

DropTable IronScrap Weight = 5
DropTable IronScrap Min = 1
DropTable IronScrap Max = 3

DropTable WitheredBone Weight = 1
DropTable WitheredBone Min = 1
DropTable WitheredBone Max = 1

DropTable LeatherScraps Weight = 1
DropTable LeatherScraps Min = 1
DropTable LeatherScraps Max = 1
```
