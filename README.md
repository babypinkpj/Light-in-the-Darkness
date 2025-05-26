# Light-in-the-Darkness
Game OverviewTitle: Light in the DarknessGenre: Survival Horror, 2DPlatform: Mobile (Android/iOS)Target Audience:
Ages 15 - 30
Players seeking thrilling and immersive gameplay
Players interested in atmospheric and artistic visuals
Game ConceptPlayers take on the role of Lucifer Bloodbrew, a lone knight surviving in a dying world plagued by a mysterious epidemic. Armed only with his family sword and a magical lantern called the Lantern of Fate, Lucifer must journey through darkness while avoiding being consumed by it—both literally and metaphorically.
The game combines mechanics from 2D horror titles such as Inside and Reveal the Deep, emphasizing escape and survival over confrontation. Its visual and thematic inspirations also borrow heavily from the Souls-like fantasy genre (e.g., Dark Souls, Demon's Souls), incorporating medieval designs, mythological references, and a haunting narrative.
Core Features1. Survival MechanicsPlayers have limited life energy (3 hearts) per session.
Players must collect crystals to slow down encroaching darkness.
If all hearts are lost, players can either wait for a recharge, watch ads, or use in-app purchases to continue playing.
2. The Darkness (Main Threat)An ever-present demonic force that follows the player.
Represented visually and affects gameplay by chasing the player.
3. Crystal SystemSpecial crystals scattered throughout the levels.
ฺIncrease player health points.
4. Diamonds SystemSpecial crystals scattered throughout the levels.
Boost atk and speed of player.
5. Lighting SystemGlobal Light 2D with low intensity (0.1) for atmospheric darkness.
Spotlight 2D attached to the player as the only light source.
Additional lighting is added to certain enemies to ensure visibility.
6. UI & User ExperienceMinimalist UI for mobile platforms.
Focuses on clarity during gameplay with real-time health and control feedback.
7. Energy & Monetization SystemHeart regeneration mechanic with wait-time or ad-based continuation.
In-app purchases available for:
Additional skins
Removing ads
Slowing down enemy difficulty
Boosting flashlight radius
8. Skins & Gacha SystemUnlock cosmetic armor sets with gacha mechanics.
Some armor may offer gameplay advantages.
9. Levels & ProgressionUnlock-based level system.
Higher levels reveal more lore about the apocalypse and Lucifer’s fate.
Business ModelMonetizationAd-based revenue model: 10–40 impressions/user/day = $2–12 per 1000 impressions
In-app purchases: Skins, heart refills, difficulty modifiers
AudienceFree players (grind-focused)
Players seeking visual storytelling
Microtransaction-friendly users
Technical DetailsMenu SceneAnimated menu with character and item visuals.
Light effects designed to represent the guiding lantern.
Scene loading via Unity’s SceneManager (Menu = 0, Level1 = 1).
UI ElementsMobile-friendly controls.
Heart-based health system visible on screen.
Lighting SetupGlobal Light 2D (Intensity: ~0.1)
Spotlight 2D attached to player and enemies
Global volume used for color grading:
Color Adjustment
Film Grain
Tone Mapping
Player MechanicsScripts:
PlayerController: movement and attack
PlayerHealth: health tracking
AttackArea: collision and damage detection
Controls:
Auto-movement
Slows when attacking
Attack re-triggers when enemy in range
AudioUses piano-based background music to create melancholy atmosphere
Audio Mixer with:
BG music
Walk
Attack
EnemiesEnemy 1 - "The Darkness"Uses AI Pathfinding to follow player continuously
Cannot be defeated
Deals high damage to promote urgency
Enemy 2 - Infected HumansSpawn directly in front of player
Must be defeated before the Darkness catches up
Uses own Health system
Build InstructionsOpen the Unity project (Unity version X.X.X recommended)
Open MenuScene.unity
Press Play or build the game using File > Build Settings > Android/iOS
UI : To reflect feedback to player, about HP, atk, and Enemy Health.
Ensure scenes are added to Build Settings in correct order:
MenuScene (Index 0)
SampleScene (Index 1)
GameOverScene(Index 2)
ReferencesGames:
Inside by Playdead
Reveal the Deep by Lazy Monday Games
Dark Souls series by FromSoftware
Conceptual References:
Medieval fantasy aesthetics
Psychological horror themes
Souls-like storytelling and atmosphere
License & CreditsAll assets used are either original, royalty-free, or licensed appropriately for educational purposes.
This project was created as part of a university final project and is not for commercial distribution.
Light in the Darkness
Final Project – Survival Horror Game (2D)
Developed in Unity for Mobile Platform

แนวคิดเกม (Game Concept)
Light in the Darkness คือเกมแนว Survival Horror 2D ที่ผู้เล่นจะได้รับบทเป็น “Lucifer Bloodbrew” — อัศวินผู้รอดชีวิตจากโลกที่กำลังใกล้สูญสลายจากโรคระบาดลึกลับ ผู้เล่นต้องออกเดินทางในโลกอันมืดมิด พร้อมกับ "ตะเกียงแห่งโชคชะตา" และดาบประจำตระกูลเพื่อเอาตัวรอดจากปีศาจ (มนุษย์ติดเชื้อ) และ "ความมืด" ที่ไล่ตามตลอดเวลา

ความมืดในเกมนี้ไม่ได้เป็นสิ่งที่น่ากลัว แต่คือสิ่งที่น่ากลัวอย่างแท้จริง คือจิตใจของผู้เล่นต้องต่อสู้ไม่เพียงศัตรูภายนอก แต่ยังรวมถึงภายในตนเอง

Gameplay & Features
วิธีการเล่น
ผู้เล่นควบคุม Lucifer ในมุมมองด้านข้าง (2D Side-scrolling)
ใช้ไฟฉายเป็นแหล่งกำเนิดแสงเพื่อมองทาง
ต้องต่อสู้หรือหลีกเลี่ยงศัตรู 2 ประเภท:
Enemy 1: ความมืด (Darkness) ที่ตามผู้เล่นตลอดเวลา
Enemy 2: มนุษย์ติดเชื้อที่จะคอยขีดขวางผู้เล่น
ใช้ไอเทม Crystal เพื่อเพิ่มพลังชีวิต
ใช้ไอเทม Diamond เพื่อพละกำลังกายและพลังการโจมตี

หากพลังชีวิตหมด 3 ครั้ง ผู้เล่นต้องรอหรือใช้ระบบเติมเงิน/ดูโฆษณา หรือสามารถกดแบนเนอร์เพื่อเพิ่มพลังชีวิต
ฟีเจอร์หลัก
ระบบพลังชีวิตจำกัด พร้อมระบบเติมพลัง
ระบบ Skin (กาชา) มีผลทั้งความงามและช่วยเล่น
UI เรียบง่าย เน้นการมองเห็นชัดเจนสำหรับมือถือ
ระบบ AI Enemy ที่หลากหลาย: ทั้งไล่ตาม และบล็อกเส้นทาง
ระบบแสงและเสียงสมจริง: ใช้ Global Light, Spotlight และเพลงเปียโนที่สื่ออารมณ์
ระบบ In-App Purchase และ Reward Ads เพื่อซื้อไอเทม/ผ่านด่านไวขึ้น

แรงบันดาลใจและอ้างอิง
องค์ประกอบ	ได้แรงบันดาลใจจาก
บรรยากาศเกม	Inside, Reveal the Deep
ธีมยุคกลาง & อัศวิน	Dark Souls, Demon Souls
ระบบหลบหนีศัตรู	Limbo, Little Nightmares
กลไกกาชา & Monetization	เกมมือถือ RPG ยอดนิยม

องค์ประกอบทางเทคนิค
Scene Overview
Menu Scene: มีอนิเมชั่นเล็ก ๆ และไฟส่องสว่างตะเกียงนำทาง

Load Scene: ใช้ SceneManager.LoadScene(index) เพื่อโหลดฉากถัดไปตาม Index

Lighting System
Global Light 2D: ความมืดโดยรวม (intensity ≈ 0.1)
Spotlight 2D: แสงเฉพาะจากผู้เล่น
Global Volume Effects: เพิ่ม Film Grain, Color Adjustment, Tone Mapping

Player System
PlayerController.cs: ควบคุมการเดิน-โจมตี
PlayerHealth.cs: ตรวจสอบ HP
AttackArea.cs: ตรวจสอบการชนศัตรู
Animation: Idle / Walk / Attack / Death ใช้ Animator & Bone-based Rigging

Enemy Types
Enemy 1 (Darkness): ใช้ AI Path ไล่ตามผู้เล่น / โจมตีแรง / ไม่สามารถฆ่าได้
Enemy 2 (Infected): โจมตีจากด้านหน้า / กำจัดได้ / เพิ่มแรงกดดันในการเคลื่อนไหว
EnemyHealth.cs: ระบบตรวจจับการโจมตีและลด HP

Sound & Music
ใช้ AudioSource และ AudioMixer
เพลงธีมเปียโนหม่นเศร้า (BG music, Walk, Attack)

๊UI 
มีการบอกค่าพลังชีวิตของศัตรู ค่าการโจมตี และค่าพลังชีวิตของศัตรู เพื่อเป็น feedback ให้กับผู้เล่น

วิธี Build
Unity 2D (เวอร์ชัน 2022 ขึ้นไป)
ระบบ URP หรือ 2D Renderer
Android Build Support

วิธี Build เกมลง Android
เปิดโปรเจกต์ใน Unity
ไปที่ File > Build Settings
เลือก Platform: Android → Click "Switch Platform"
คลิก “Add Open Scenes”
ตั้งค่าชื่อ Package และอื่น ๆ ใน Player Settings
คลิก “Build” และเลือกที่จัดเก็บ .apk

Business Model
Free-to-Play	เล่นฟรี พร้อมโฆษณาและเวลารอ
Reward Ads	ดูโฆษณาเพื่อเติมพลังชีวิตหรือเปิดกาชา
In-App Purchase	ซื้อชุดเกราะ Skin / ลบโฆษณา / ลดความเร็วปีศาจ
Coin Economy	ได้จากเล่นเกม หรือซื้อด้วยเงินจริง

หมายเหตุ: รายได้เฉลี่ยคาดการณ์สำหรับผู้ใช้ 25–100 คนต่อวัน: $4 – $12 ต่อวัน
กลุ่มเป้าหมาย (Target Audience)
ผู้เล่นอายุ 15–30 ปี
ชื่นชอบเกม กราฟิกหม่น, ตื่นเต้น, เนื้อเรื่องลึก
สนใจเกมที่ ภาพสวย + เล่นคนเดียว

สรุป
เกม Light in the Darkness เป็นการผสมผสานแนวคิด ความกลัว, ความรอด, และการค้นหาความหมาย ภายใต้สภาพแวดล้อมอันโหดร้าย พร้อมกับระบบเกมที่ปรับให้เหมาะสมกับมือถือ ทั้งในเชิงกราฟิก UI และการสร้างรายได้อย่างยั่งยืน

“จงอย่าให้แสงสุดท้ายในใจของเจ้า...ดับไปก่อนที่โลกจะดับสิ้น”