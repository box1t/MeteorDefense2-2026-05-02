# 🚀 Meteor Defense

**Meteor Defense** — это динамичная аркадная игра в космосе, где игрок управляет камерой вокруг корабля и отражает поток метеоритов, надвигающихся со всех сторон.

- PC (Ubuntu)
- Unity 6.3 LTS

---

## 🎮 Геймплей

Игрок находится в центре космического пространства рядом с кораблём и должен уничтожать метеориты до того, как они достигнут цели.
Камера свободно вращается вокруг корабля, позволяя вести бой на 360°.

Метеориты появляются волнами с разными паттернами движения и постепенно увеличивают сложность игры.

## Видеодемонстрация
[Ссылка на геймплей](https://drive.google.com/file/d/1sa3inY0uyd7gCAMYsT2z9CiLwTrwtR37/view?usp=sharing)

![drone-wave](screens/drone-wave.png)

![main-menu](screens/main-menu.png)

![shoot-lightning.png](screens/shoot-lightning.png)
---
# MeteorDefense2 — Gameplay Systems README

## ⚙️ Реализованные механики

* 🎥 **Орбитальная камера (360°)** — вращение вокруг корабля
* ☄️ **Волновой спавн метеоритов**:

  * конус
  * стена
  * стена с "дырой"
* 🔁 **Телепорты** — позволяют метеоритам менять позицию в пространстве, создавая неожиданные траектории
* 📈 **Рост сложности** с повышением уровня
* 🔫 **Система стрельбы**:

  * стрельба по направлению камеры
  * homing projectile system
  * projectile targeting
  * FirePoint spawn system
* 🎯 **Автоприцеливание (Aim Assist)**
* 🔒 **Lock-on система** — захват ближайшей цели
* 💥 **Уничтожение метеоров**:

  * визуальные эффекты (взрыв)
  * всплывающий текст (+1)
* 📊 **Счётчик уничтоженных метеоров**
* 🧠 **Ограничение количества метеоров на сцене**
* ⚡ **Кеширование компонентов** — оптимизация работы (снижение количества вызовов Find и GetComponent)
* 🚀 **Particle Thrusters** — реактивное пламя из сопел корабля
* 🛰 **Drone Support System**
* ⚡ **EMP / Magnetic Pulse Ability**
* 📉 **Cooldown System**
* 🌌 **Space Skybox Animation**
* 🎥 **Camera Shake**
* ✨ **Floating UI Feedback**
* ☄️ **Physics-based Meteors**
* 🚪 **Portal Teleportation System**
* ⚙️ **Optimization Systems**
* 🔥 **Projectile VFX**

---

# 🎮 Управление

| Действие        | Управление          |
| --------------- | ------------------- |
| Вращение камеры | ПКМ + движение мыши |
| Стрельба        | ЛКМ                 |
| EMP-волна дрона | V                   |
| Зум камеры      | Колесо мыши         |

---

# 🎯 Цель игры

Уничтожать как можно больше метеоритов, адаптируясь к увеличивающейся сложности и атакам с разных направлений.

---

# 💡 Особенности

* Бой ведётся **в полном 3D пространстве**
* Игрок может атаковать цели **с любой стороны**
* Телепорты добавляют элемент непредсказуемости
* Камера напрямую влияет на эффективность стрельбы
* Projectile system автоматически корректирует траекторию
* EMP drone помогает расчищать пространство при окружении
* Волны постоянно меняют структуру атак

---

# 🛠 Технологии

* Unity 6
* C#
* Rigidbody Physics
* Raycast / SphereCast
* URP
* TextMeshPro
* Particle System
* GPU Instancing
* Static Batching

---

# 📌 Статус проекта

Прототип с завершённым игровым циклом и оптимизированной архитектурой.

---

# 🧠 Основные системы проекта

---

## 🎮 GameManager.cs

Центральный управляющий скрипт игры.

### Отвечает за:

* текущий уровень
* таймер перехода между уровнями
* увеличение сложности
* хранение счёта
* победу / завершение игры
* progression loop

---

## ☄️ Meteor.cs

Основной gameplay-скрипт метеоритов.

### Реализует:

* физическое движение
* Rigidbody physics
* collision system
* взаимодействие с игроком
* уничтожение метеора
* визуальные эффекты
* floating text
* push system от EMP
* teleportation support
* damage interaction

### Features:

* `DestroyMeteor()`
* `Push()`
* `OnCollisionEnter()`
* explosion spawning
* floating UI
* spawner notifications

---

## 🌊 MeteorSpawnerPRO.cs

Продвинутая procedural wave system.

### Отвечает за:

* генерацию волн
* procedural spawn patterns
* динамическую сложность
* ограничение количества meteors
* wave pacing
* level scaling

### Spawn Patterns:

* cone attack
* meteor wall
* wall with hole
* directional spawn logic

### Optimization:

* max meteor cap
* velocity-based spawning
* cached player reference

---

## 🔫 ShipCombat.cs

Основная система стрельбы.

### Реализует:

* projectile spawning
* FirePoint muzzle system
* projectile targeting
* target acquisition
* meteor tracking
* homing logic

### Исправленные проблемы:

* orbiting projectiles
* backward shooting
* circular projectile movement
* projectile stacking around player

---

## 🚀 Projectile.cs

Поведение projectile.

### Features:

* movement to target
* target tracking
* homing trajectory
* collision detection
* meteor destruction
* lifetime control

---

## 🎯 LockOnSystem.cs

Система захвата целей.

### Реализует:

* поиск ближайшего метеора
* assist radius
* directional filtering
* aim assist

### Используется:

* projectile targeting
* auto-aim
* combat readability

---

## 🎥 CameraOrbit.cs

Орбитальная камера.

### Отвечает за:

* вращение камеры вокруг корабля
* управление yaw/pitch
* зум
* LookAt targeting
* smooth orbiting

---

## ✨ FloatingText.cs

Floating combat feedback.

### Реализует:

* движение текста вверх
* fade-out animation
* auto destroy
* UI feedback

---

## 📊 ScoreUI.cs

Система отображения счёта.

### Features:

* отображение уничтоженных метеоров
* realtime update
* UI synchronization

---

## 📈 LevelUI.cs

Отображение уровня и сложности.

### Реализует:

* current level display
* difficulty text
* wave progression feedback

---

## 📖 StoryManager.cs

Система narrative / event messaging.

### Отвечает за:

* отображение wave messages
* progression events
* gameplay notifications

---

## 🌌 SkyboxRotation.cs

Анимация космоса.

### Реализует:

* вращение skybox
* усиление ощущения движения
* depth illusion

---

## 🎥 CameraShake.cs

Система тряски камеры.

### Используется:

* при столкновениях
* при damage events
* для усиления impact feedback

---

## 🌀 Portal.cs

Телепортационная система.

### Реализует:

* teleport between portals
* сохранение velocity
* anti-loop protection

### Использует:

```csharp
isTeleporting
```

---

# 🛰 Drone System

---

## 🚁 Drone Support Unit

В игру внедрён drone companion.

### Drone:

* сопровождает корабль
* имеет собственную модель
* поддерживает EMP-ability
* взаимодействует с meteors

---

## ⚡ EMP Ability

### Активация:

```text
V
```

### Эффект:

* отталкивает nearby meteors
* расчищает пространство
* помогает выживать в плотных wave

---

## Cooldown System

EMP ability:

* имеет cooldown
* предотвращает spam
* создаёт tactical timing

---

# 🚀 Thruster VFX

---

## Engine Particles

Добавлены:

* engine flames
* dual thruster particles
* sci-fi propulsion effect

### Particle Features:

* looping particles
* emissive look
* configurable colors

---

# ☄️ Physics Systems

---

## Rigidbody Meteors

Метеоры:

* используют physics
* имеют velocity-based movement
* взаимодействуют через collisions

---

## Collision System

### Реализует:

* столкновения с player
* camera shake
* player reset
* future damage system hooks

---

# ⚙️ Оптимизация

---

## GPU Instancing

Используется для:

* meteors
* repeated meshes
* repeated materials

---

## Static Batching

Используется для:

* portals
* static geometry
* environmental meshes

---

## Cached References

Уменьшено количество:

```csharp
Find()
GetComponent()
```

---

## Particle Optimization

Оптимизированы:

* particle count
* trail lifetime
* VFX cleanup

---

## Meteor Limits

Используется:

```csharp
maxMeteors
```

для предотвращения:

* FPS drops
* scene overload
* physics overload

---

# 🚫 Удалённые / Переработанные системы

---

## ShootingSystem.cs

Удалён из архитектуры.

### Причины:

* конфликтовал с ShipCombat
* вызывал circular shooting
* projectiles летали по орбите

### Заменён на:

```text
ShipCombat
+
Projectile targeting system
```

---

# 🔮 Planned Features

---

## 🛠 Ship Damage System

Планируется:

* hull damage
* visual damage states
* dirt rendering
* repair mechanics

---

## 🌌 Space Dust

Планируется:

* volumetric particles
* traversal depth
* cinematic movement

---

## 🤖 Advanced Drone AI

Планируется:

* autonomous combat
* repair drone
* shield drone
* combat assistance

---

## ☄️ Advanced Enemy Waves

Планируется:

* elite meteors
* boss waves
* adaptive difficulty
* dynamic pacing

---

# 🎮 Gameplay Loop

```text
Spawn Wave
→ Meteors attack
→ Player shoots
→ Drone clears space
→ Destroy meteors
→ Survive escalation
→ Difficulty increases
→ Next wave
```

---

# 🎯 Жанр проекта

```text
Arcade Space Survival
+
Sci-Fi Wave Defense
+
3D Action Prototype
```

