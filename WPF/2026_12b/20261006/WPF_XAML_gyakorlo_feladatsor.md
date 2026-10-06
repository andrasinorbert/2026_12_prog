# WPF/XAML gyakorló feladatsor

## Munkavégzés

1. Hozz létre egy új **WPF Application** projektet.
2. Minden feladatot külön ablakban vagy külön projektben is elkészíthetsz.
3. Minden lépés után indítsd el a programot.
4. Ha hibát kapsz, először a XAML nyitó- és záróelemeit ellenőrizd.

> **Fontos:** A `MainWindow.xaml` fájlban dolgozz. C#-kódot csak ott írj, ahol a feladat külön kéri.

---

# 0. feladat - kezdőfelület

`MainWindow.xaml` fájlban hozz létre minden feladathoz egy gombot. Kattintásra jelenjen meg a feladathoz tartozó ablak.

# 1. feladat – Az első ablak

**Nehézség:** ★☆☆  
**Gyakorolt elemek:** `Window`, `Grid`, `TextBlock`

Készíts egy 800 × 500 képpont méretű ablakot!

Az ablak:

- címe legyen **WPF gyakorlás**;
- a képernyő közepén jelenjen meg;
- tartalmazzon egy `Grid` elemet;
- középen jelenítse meg a **Helló, WPF!** szöveget;
- a szöveg legyen 32-es méretű és félkövér.

Kiindulás:

```xml
<Window x:Class="Gyakorlas.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="..."
        Width="..."
        Height="...">

    <Grid>
        <!-- Ide kerül a TextBlock. -->
    </Grid>
</Window>
```


# 2. feladat – Közös tulajdonságok

**Nehézség:** ★☆☆  
**Gyakorolt tulajdonságok:** `Width`, `Height`, `Margin`, `Alignment`, `Background`, `Foreground`, `ToolTip`

Helyezz el egy gombot az ablakban!

A gomb:

- felirata legyen **Indítás**;
- legyen 180 képpont széles és 55 képpont magas;
- kerüljön az ablak közepére;
- legyen lila hátterű és fehér szövegű;
- kapjon 10 képpontos külső margót;
- az egérrel fölé állva jelenjen meg a **Program indítása** súgószöveg.

Kiindulás:

```xml
<Button Content="Indítás"
        Width="..."
        Height="..."
        Margin="..."
        HorizontalAlignment="..."
        VerticalAlignment="..."
        Background="..."
        Foreground="..."
        ToolTip="..." />
```

### Pluszfeladat

Állítsd be a gomb betűméretét 20-ra, a betűvastagságát pedig félkövérre!

---

# 3. feladat – Egymás alatti elemek

**Nehézség:** ★☆☆  
**Gyakorolt elemek:** `StackPanel`, `TextBlock`, `TextBox`, `PasswordBox`, `Button`

Készíts egyszerű bejelentkező felületet `StackPanel` használatával!

Az elemek sorrendje:

1. **Bejelentkezés** cím;
2. **Felhasználónév** felirat;
3. `TextBox`;
4. **Jelszó** felirat;
5. `PasswordBox`;
6. **Belépés** gomb.

Elvárások:

- a panel szélessége legyen 350;
- a panel kerüljön az ablak közepére;
- az elemek között `Margin` segítségével legyen térköz;
- a cím legyen 28-as, félkövér és középre igazított;
- a beviteli mezők magassága legyen legalább 35;
- a jelszó karaktere `●` legyen.

---

# 4. feladat – Sorok és oszlopok

**Nehézség:** ★★☆  
**Gyakorolt elem:** `Grid`

Készíts adatbeviteli űrlapot `Grid` használatával!

Az űrlapon legyen három sor:

| Bal oldali oszlop | Jobb oldali oszlop |
|---|---|
| Név: | `TextBox` |
| E-mail: | `TextBox` |
| Életkor: | `TextBox` |

Elvárások:

- az első oszlop szélessége igazodjon a tartalmához: `Auto`;
- a második oszlop töltse ki a maradék helyet: `*`;
- a sorok magassága legyen `Auto`;
- minden elem kapjon 6 képpontos margót;
- a `Grid` kapjon 20 képpontos margót.

Kiindulás:

```xml
<Grid Margin="20">
    <Grid.RowDefinitions>
        <!-- Három sor -->
    </Grid.RowDefinitions>

    <Grid.ColumnDefinitions>
        <!-- Két oszlop -->
    </Grid.ColumnDefinitions>

    <!-- Címkék és beviteli mezők -->
</Grid>
```

### Pluszfeladat

Helyezz el egy **Mentés** gombot a negyedik sorban! A gomb fogja át mindkét oszlopot a `Grid.ColumnSpan` segítségével.

---

# 5. feladat – Keretezett névjegykártya

**Nehézség:** ★★☆  
**Gyakorolt elemek:** `Border`, `StackPanel`, `TextBlock`

Készíts egy egyszerű névjegykártyát!

A kártya tartalmazza:

- a saját nevedet;
- az osztályodat;
- egy tetszőleges e-mail-címet;
- egy rövid bemutatkozó mondatot.

A `Border` beállításai:

- `BorderBrush="DarkSlateBlue"`;
- `BorderThickness="2"`;
- `CornerRadius="15"`;
- `Padding="20"`;
- `Background="Lavender"`;
- legfeljebb 450 képpont szélesség.

> A `Border` csak egy közvetlen gyermekelemet tartalmazhat. Több szöveghez helyezz el benne egy `StackPanel` elemet!

### Pluszfeladat

Tegyél a kártya tetejére egy `Image` elemet. Használd a `Stretch="Uniform"` beállítást!

---

# 6. feladat – Választási lehetőségek

**Nehézség:** ★★☆  
**Gyakorolt elemek:** `CheckBox`, `RadioButton`, `GroupBox`

Készíts kérdőívrészletet!

## Kedvelt témák

`CheckBox` elemekkel lehessen több lehetőséget is kiválasztani:

- programozás;
- grafika;
- játékfejlesztés;
- adatbázisok.

## Kedvenc napszak

`RadioButton` elemekkel csak egy lehetőség legyen választható:

- reggel;
- délután;
- este.

Elvárások:

- a két kérdés külön `GroupBox` elemben legyen;
- a RadioButton elemek azonos `GroupName` értéket kapjanak;
- az **este** lehetőség legyen alapból kijelölve.

---

# 7. feladat – Városok és tantárgyak

**Nehézség:** ★★☆  
**Gyakorolt elemek:** `ComboBox`, `ListBox`

Készíts két választólistát!

## ComboBox

A legördülő lista tartalma:

- Budapest;
- Szeged;
- Pécs;
- Győr;
- Miskolc.

Az első elem legyen alapból kiválasztva.

## ListBox

A lista tartalma:

- Programozás;
- Adatbázis-kezelés;
- Webfejlesztés;
- Hálózatok;
- Grafika.

A `SelectionMode` értéke legyen `Extended`, hogy több elem is kijelölhető legyen.

### Pluszfeladat

Helyezd egymás mellé a két listát egy kétoszlopos `Grid` segítségével!

---

# 8. feladat – Gombkattintás C#-ban

**Nehézség:** ★★☆  
**Gyakorolt elemek:** `x:Name`, `Button`, `TextBox`, `Click`, `MessageBox`

Készíts névköszöntő programot!

A felület tartalmazzon:

- egy `TextBox` elemet, amelynek neve `txtNev`;
- egy **Köszöntés** feliratú gombot;
- egy `TextBlock` elemet, amelynek neve `txtEredmeny`.

A gomb XAML-kódja:

```xml
<Button Content="Köszöntés"
        Click="Koszontes_Click" />
```

A `MainWindow.xaml.cs` fájlban hozd létre az eseménykezelőt:

```csharp
private void Koszontes_Click(object sender, RoutedEventArgs e)
{
    // Olvasd ki a nevet a txtNev mezőből.
    // Jelenítsd meg: Szia, [név]!
}
```

Elvárások:

- a köszöntés a `txtEredmeny` elemben jelenjen meg;
- ha a névmező üres, jelenjen meg egy figyelmeztető `MessageBox`;
- a gomb legyen az ablak alapértelmezett gombja az `IsDefault="True"` beállítással.

### Tesztesetek

| Beírt érték | Elvárt eredmény |
|---|---|
| Anna | Szia, Anna! |
| Péter | Szia, Péter! |
| üres mező | Figyelmeztető üzenet |

---

# 9. feladat – Csúszka és folyamatjelző

**Nehézség:** ★★☆  
**Gyakorolt elemek:** `Slider`, `ProgressBar`, adatkötés

Készíts egy százalékbeállító felületet!

Elvárások:

- a `Slider` minimuma legyen 0;
- a maximuma legyen 100;
- a kezdőérték legyen 50;
- a `TickFrequency` értéke legyen 10;
- az érték igazodjon az osztásokhoz az `IsSnapToTickEnabled="True"` segítségével;
- alatta legyen egy `ProgressBar`;
- a folyamatjelző értéke kövesse a csúszkát.

Segítség az adatkötéshez:

```xml
<Slider x:Name="sldErtek"
        Minimum="0"
        Maximum="100"
        Value="50" />

<ProgressBar Minimum="0"
             Maximum="100"
             Value="{Binding ElementName=sldErtek, Path=Value}" />
```

### Pluszfeladat

Jelenítsd meg a csúszka aktuális értékét egy `TextBlock` elemben is!

---

# 10. feladat – Mini regisztrációs felület

**Nehézség:** ★★★  
**Gyakorolt elemek:** az eddigiek összekapcsolása

Készíts egyszerű regisztrációs felületet!

Az ablak tartalmazza:

- **Regisztráció** címet;
- névmezőt;
- e-mail-mezőt;
- jelszómezőt;
- születési dátumhoz `DatePicker` elemet;
- városválasztó `ComboBox` elemet;
- hírlevél-feliratkozási `CheckBox` elemet;
- **Regisztráció** és **Mégse** gombot.

Elrendezési követelmények:

- a teljes űrlap egy `Border` elemben legyen;
- a mezők elrendezéséhez használj `Grid` elemet;
- a gombokat vízszintes `StackPanel` rendezze egymás mellé;
- a feliratok és mezők igazodjanak egymáshoz;
- használj következetes margókat és térközöket;
- a felület maradjon használható az ablak átméretezésekor is.

A gombok beállításai:

```xml
<Button Content="Regisztráció"
        IsDefault="True" />

<Button Content="Mégse"
        IsCancel="True" />

---

# Extra feladat – Egyszerű alkalmazásváz

**Nehézség:** ★★★  
**Gyakorolt elemek:** `DockPanel`, `Menu`, `ToolBar`, `StatusBar`

- felül legyen egy `Menu` **Fájl** menüponttal;
- a Fájl menü tartalmazza az **Új**, **Mentés** és **Kilépés** elemeket;
- a Mentés és Kilépés közé kerüljön `Separator`;
- a menü alatt legyen `ToolBar` három gombbal;
- középen legyen egy nagy, több soros `TextBox`;
- alul legyen `StatusBar`, benne a **Kész** szöveg;
- az elrendezéshez használj `DockPanel` elemet.