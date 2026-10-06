A WPF XAML felületnél érdemes három nagy csoportra bontani az elemeket: **elrendezési konténerek**, **megjelenítő/vezérlő elemek**, illetve **adatbeviteli és választó elemek**. Az alábbi összefoglaló úgy van felépítve, hogy tananyagként is használható legyen.

# 1. XAML alapok

A WPF felületet XAML-ben hierarchikusan írjuk le:

```xml
<Window>
    <Grid>
        <TextBlock Text="Hello WPF!" />
        <Button Content="Kattints!" />
    </Grid>
</Window>
```

A `Window` tartalmazza a felületet, az olyan elemek pedig, mint a `Grid`, `StackPanel` és `DockPanel`, elsősorban **más elemek elrendezésére** szolgálnak.

---

# 2. A legtöbb WPF elem közös attribútumai

Fontos pontosítás: **szó szerint nincs olyan XAML attribútum, amely minden elképzelhető WPF objektumnál létezik**. A felületi elemek jelentős része azonban `FrameworkElement`-ből származik, ezért ezeknél nagyon sok közös property használható.

A gyakorlatban ezeket tekinthetjük a WPF vezérlők legfontosabb közös tulajdonságainak:

| Attribútum | Jelentése | Példa |
|---|---|---|
| `x:Name` | Az elem neve, amellyel C#-ból hivatkozhatunk rá | `x:Name="btnSave"` |
| `Width` | szélesség | `Width="200"` |
| `Height` | magasság | `Height="50"` |
| `MinWidth` | minimális szélesség | `MinWidth="100"` |
| `MaxWidth` | maximális szélesség | `MaxWidth="500"` |
| `MinHeight` | minimális magasság | `MinHeight="30"` |
| `MaxHeight` | maximális magasság | `MaxHeight="200"` |
| `Margin` | külső térköz | `Margin="10"` |
| `HorizontalAlignment` | vízszintes elhelyezés | `HorizontalAlignment="Center"` |
| `VerticalAlignment` | függőleges elhelyezés | `VerticalAlignment="Center"` |
| `Visibility` | láthatóság | `Visibility="Collapsed"` |
| `Opacity` | átlátszóság 0–1 között | `Opacity="0.5"` |
| `IsEnabled` | használható-e az elem | `IsEnabled="False"` |
| `ToolTip` | egérrel rámutatva megjelenő segítség | `ToolTip="Mentés"` |
| `Tag` | tetszőleges extra adat tárolására | `Tag="123"` |

### Margin

A `Margin` különösen fontos:

```xml
<Button Margin="10" />
```

Minden oldalon 10.

```xml
<Button Margin="10,20" />
```

- bal/jobb: 10
- fent/lent: 20

```xml
<Button Margin="10,20,30,40" />
```

Sorrend:

**bal, fent, jobb, lent**

---

# 3. Control típusú elemek további közös tulajdonságai

A `Button`, `TextBox`, `CheckBox`, `ComboBox` stb. `Control` leszármazottak, ezért további közös propertyket kapnak.

| Attribútum | Jelentése |
|---|---|
| `Background` | háttér |
| `Foreground` | előtér/szöveg színe |
| `FontFamily` | betűtípus |
| `FontSize` | betűméret |
| `FontWeight` | betűvastagság |
| `FontStyle` | pl. dőlt |
| `Padding` | belső térköz |
| `BorderBrush` | keret színe |
| `BorderThickness` | keret vastagsága |
| `HorizontalContentAlignment` | tartalom vízszintes igazítása |
| `VerticalContentAlignment` | tartalom függőleges igazítása |
| `TabIndex` | Tab billentyű sorrendje |
| `IsTabStop` | Tab-bal fókuszálható-e |

Például:

```xml
<Button Content="Mentés"
        Width="150"
        Height="50"
        Margin="10"
        Background="DarkGreen"
        Foreground="White"
        FontSize="18"
        FontWeight="Bold"
        Padding="10"/>
```

A továbbiakban ezeket a közös tulajdonságokat **nem sorolom fel újra**, csak az adott elemre jellemző fontosabbakat.

---

# 4. Elrendezési elemek

## Grid

A WPF egyik legfontosabb konténere.

A felületet **sorokra és oszlopokra** oszthatjuk.

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="200"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <Button Grid.Row="0"
            Grid.Column="0"
            Content="Gomb"/>

</Grid>
```

### Fontos sajátosságok

`Grid.Row`

Megadja, melyik sorban legyen az elem.

`Grid.Column`

Megadja, melyik oszlopban legyen.

`Grid.RowSpan`

Több sort foglalhat el:

```xml
Grid.RowSpan="2"
```

`Grid.ColumnSpan`

Több oszlopot foglalhat el:

```xml
Grid.ColumnSpan="3"
```

### Méretezés

Fix:

```xml
<RowDefinition Height="100"/>
```

Tartalomhoz igazodó:

```xml
<RowDefinition Height="Auto"/>
```

Maradék hely:

```xml
<RowDefinition Height="*"/>
```

Arányosan:

```xml
<RowDefinition Height="2*"/>
<RowDefinition Height="1*"/>
```

→ 2:1 arány.

**Mikor használjuk?**

Összetettebb felületekhez, űrlapokhoz, dashboardokhoz és általános ablakszerkezet kialakításához. A legtöbb WPF alkalmazásban ez a fő layout elem.

---

# 5. StackPanel

Az elemeket egymás után rendezi.

```xml
<StackPanel>
    <Button Content="Első"/>
    <Button Content="Második"/>
    <Button Content="Harmadik"/>
</StackPanel>
```

Alapból függőlegesen:

```text
[ Első ]

[ Második ]

[ Harmadik ]
```

### Egyedi/fontos tulajdonság

`Orientation`

```xml
<StackPanel Orientation="Horizontal">
```

Lehetséges:

```text
Vertical
Horizontal
```

Horizontal esetén:

```text
[ Első ] [ Második ] [ Harmadik ]
```

**Mikor használjuk?**

Ha egyszerűen egymás alá vagy mellé akarunk tenni elemeket. Például egy bejelentkező űrlap mezőit.

---

# 6. WrapPanel

Hasonló a `StackPanel`-hez, de ha elfogy a hely, **új sorban/oszlopban folytatja**.

```xml
<WrapPanel>
    <Button Content="1"/>
    <Button Content="2"/>
    <Button Content="3"/>
    <Button Content="4"/>
</WrapPanel>
```

Például:

```text
[1] [2] [3]

[4]
```

### Fontos tulajdonságok

```xml
Orientation="Horizontal"
ItemWidth="100"
ItemHeight="50"
```

**Mikor használjuk?**

Csempék, képek, gombgyűjtemények, kategóriák stb. megjelenítésére, amikor az elemeknek alkalmazkodniuk kell a rendelkezésre álló helyhez.

---

# 7. DockPanel

Az elemeket valamelyik oldalhoz rögzíthetjük.

```xml
<DockPanel>

    <Button DockPanel.Dock="Top"
            Content="Felső"/>

    <Button DockPanel.Dock="Left"
            Content="Bal"/>

    <TextBlock Text="Középső tartalom"/>

</DockPanel>
```

Lehetséges értékek:

```text
Top
Bottom
Left
Right
```

Fontos:

```xml
LastChildFill="True"
```

Az utolsó elem kitölti a maradék területet.

**Mikor használjuk?**

Tipikus alkalmazásstruktúrákhoz:

```text
+-----------------------------+
|           Toolbar           |
+------+----------------------+
| Menü |                      |
|      |     Tartalom         |
|      |                      |
+------+----------------------+
|          StatusBar          |
+-----------------------------+
```

---

# 8. Canvas

Abszolút pozicionálást tesz lehetővé.

```xml
<Canvas>

    <Button Canvas.Left="100"
            Canvas.Top="50"
            Content="Gomb"/>

</Canvas>
```

Fontos attached propertyk:

```text
Canvas.Left
Canvas.Right
Canvas.Top
Canvas.Bottom
Canvas.ZIndex
```

**Mikor használjuk?**

Rajzolás, játék, diagram, egyedi grafikus felület esetén.

Normál alkalmazásfelület kialakítására általában **nem ajánlott**, mert rosszul alkalmazkodik az ablak átméretezéséhez.

---

# 9. Border

Egy másik elem köré keretet és hátteret készíthetünk.

```xml
<Border BorderBrush="Black"
        BorderThickness="2"
        CornerRadius="10"
        Padding="20">

    <TextBlock Text="Hello"/>

</Border>
```

### Jellemző tulajdonságok

```text
BorderBrush
BorderThickness
CornerRadius
Padding
Background
```

Fontos: egy `Border` közvetlenül **egy gyermekelemet** tartalmazhat.

Ha több kell:

```xml
<Border>
    <StackPanel>

        <TextBlock/>
        <Button/>
        <Button/>

    </StackPanel>
</Border>
```

---

# 10. TextBlock

Szöveg **megjelenítésére** szolgál.

```xml
<TextBlock Text="Hello World"/>
```

### Fontos tulajdonságok

```text
Text
TextAlignment
TextWrapping
TextTrimming
LineHeight
```

Például:

```xml
<TextBlock Text="Ez egy hosszabb szöveg..."
           TextWrapping="Wrap"
           TextAlignment="Center"/>
```

**Mikor használjuk?**

Címkék, címek, leírások és általában nem szerkeszthető szöveg megjelenítésére.

---

# 11. Label

Szintén szöveg/tartalom megjelenítésére használható, de tipikusan egy másik vezérlő **címkéjeként**.

```xml
<Label Content="Felhasználónév:"/>
```

Fontos tulajdonság:

```text
Content
Target
```

A `TextBlock` és `Label` hasonló, de általános szövegmegjelenítésre általában `TextBlock`-ot használunk.

---

# 12. Button

Kattintható gomb.

```xml
<Button Content="Mentés"
        Click="Button_Click"/>
```

C#:

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Sikeres mentés!");
}
```

### Fontos tulajdonságok

```text
Content
IsDefault
IsCancel
Command
CommandParameter
```

### Fontos esemény

```text
Click
```

A `Content` nem csak szöveg lehet:

```xml
<Button>
    <StackPanel Orientation="Horizontal">
        <Image Source="save.png"/>
        <TextBlock Text="Mentés"/>
    </StackPanel>
</Button>
```

Ez a WPF egyik nagyon fontos sajátossága: számos vezérlő **tetszőleges UI tartalmat** képes befogadni.

---

# 13. TextBox

Felhasználói szövegbevitel.

```xml
<TextBox x:Name="txtName"
         Text="Norbert"/>
```

C#:

```csharp
string nev = txtName.Text;
```

### Fontos tulajdonságok

```text
Text
MaxLength
IsReadOnly
AcceptsReturn
AcceptsTab
TextWrapping
CharacterCasing
SelectionStart
SelectionLength
SelectedText
```

Többsoros:

```xml
<TextBox AcceptsReturn="True"
         TextWrapping="Wrap"
         Height="200"/>
```

### Fontos események

```text
TextChanged
SelectionChanged
```

---

# 14. PasswordBox

Jelszó bevitelére.

```xml
<PasswordBox x:Name="pwdPassword"/>
```

C#:

```csharp
string password = pwdPassword.Password;
```

### Fontos tulajdonságok

```text
Password
MaxLength
PasswordChar
```

Például:

```xml
<PasswordBox PasswordChar="●"/>
```

---

# 15. CheckBox

Logikai választás:

```xml
<CheckBox Content="Elfogadom a feltételeket"/>
```

### Fontos tulajdonságok

```text
IsChecked
IsThreeState
Content
```

C#:

```csharp
if (checkBox.IsChecked == true)
{
    // be van jelölve
}
```

Háromállapotú mód:

```text
true
false
null
```

ehhez:

```xml
IsThreeState="True"
```

### Események

```text
Checked
Unchecked
Indeterminate
```

---

# 16. RadioButton

Egymást kizáró lehetőségek közötti választás.

```xml
<RadioButton Content="Férfi"
             GroupName="gender"/>

<RadioButton Content="Nő"
             GroupName="gender"/>
```

### Fontos tulajdonságok

```text
IsChecked
GroupName
Content
```

A `GroupName` mondja meg, mely RadioButtonok tartoznak egy csoportba.

Például:

```text
Fizetési mód:

( ) Készpénz
(●) Bankkártya
( ) Átutalás
```

---

# 17. ComboBox

Legördülő lista.

```xml
<ComboBox x:Name="cmbCity">
    <ComboBoxItem Content="Budapest"/>
    <ComboBoxItem Content="Szeged"/>
    <ComboBoxItem Content="Pécs"/>
</ComboBox>
```

### Fontos tulajdonságok

```text
Items
ItemsSource
SelectedItem
SelectedIndex
SelectedValue
SelectedValuePath
DisplayMemberPath
IsEditable
IsDropDownOpen
```

Például:

```xml
SelectedIndex="0"
```

→ az első elem legyen kiválasztva.

### Fontos esemény

```text
SelectionChanged
```

---

# 18. ListBox

Egyszerre több elem látható listája.

```xml
<ListBox>
    <ListBoxItem Content="C#"/>
    <ListBoxItem Content="Java"/>
    <ListBoxItem Content="Python"/>
</ListBox>
```

### Fontos tulajdonságok

```text
Items
ItemsSource
SelectedItem
SelectedItems
SelectedIndex
SelectionMode
```

`SelectionMode`:

```text
Single
Multiple
Extended
```

---

# 19. ListView

A `ListBox` fejlettebb változataként érdemes elképzelni.

Objektumok strukturált megjelenítésére alkalmas.

Például:

```text
Név             Életkor
------------------------
Anna               22
Péter              31
Gábor              27
```

Gyakran `GridView`-val használjuk:

```xml
<ListView>
    <ListView.View>
        <GridView>

            <GridViewColumn Header="Név"
                            DisplayMemberBinding="{Binding Name}"/>

            <GridViewColumn Header="Kor"
                            DisplayMemberBinding="{Binding Age}"/>

        </GridView>
    </ListView.View>
</ListView>
```

### Fontos tulajdonságok

Nagyrészt örökli a listaelemek tulajdonságait:

```text
Items
ItemsSource
SelectedItem
SelectedIndex
SelectionMode
View
```

---

# 20. DataGrid

Táblázatos adatok kezelésére az egyik legfontosabb WPF elem.

```xml
<DataGrid ItemsSource="{Binding Students}"/>
```

Megjelenhet például:

```text
+--------+------+-------------+
| Név    | Kor  | Város       |
+--------+------+-------------+
| Anna   | 22   | Budapest    |
| Péter  | 31   | Győr        |
+--------+------+-------------+
```

### Fontos tulajdonságok

```text
ItemsSource
SelectedItem
SelectedItems
SelectedIndex

AutoGenerateColumns
CanUserAddRows
CanUserDeleteRows
CanUserResizeColumns
CanUserReorderColumns
CanUserSortColumns

IsReadOnly
SelectionMode
SelectionUnit
```

Saját oszlopok:

```xml
<DataGrid AutoGenerateColumns="False">

    <DataGrid.Columns>

        <DataGridTextColumn
            Header="Név"
            Binding="{Binding Name}"/>

        <DataGridTextColumn
            Header="Kor"
            Binding="{Binding Age}"/>

    </DataGrid.Columns>

</DataGrid>
```

Adatbázisos WPF alkalmazásoknál különösen fontos vezérlő.

---

# 21. Image

Kép megjelenítésére.

```xml
<Image Source="Images/logo.png"/>
```

### Fontos tulajdonságok

```text
Source
Stretch
StretchDirection
```

`Stretch`:

```text
None
Fill
Uniform
UniformToFill
```

A `Uniform` megtartja a kép eredeti képarányát.

---

# 22. Slider

Numerikus érték grafikus kiválasztására.

```xml
<Slider Minimum="0"
        Maximum="100"
        Value="50"/>
```

### Fontos tulajdonságok

```text
Minimum
Maximum
Value
SmallChange
LargeChange
TickFrequency
TickPlacement
IsSnapToTickEnabled
Orientation
```

### Fontos esemény

```text
ValueChanged
```

Tipikus használat:

- hangerő;
- fényerő;
- zoom;
- játékbeállítás;
- százalékos érték.

---

# 23. ProgressBar

Folyamat előrehaladásának kijelzése.

```xml
<ProgressBar Minimum="0"
             Maximum="100"
             Value="65"/>
```

### Fontos tulajdonságok

```text
Minimum
Maximum
Value
IsIndeterminate
Orientation
```

Ha nem tudjuk, meddig tart a folyamat:

```xml
<ProgressBar IsIndeterminate="True"/>
```

Ilyenkor nem százalékos előrehaladást mutat.

---

# 24. DatePicker

Dátum kiválasztása.

```xml
<DatePicker SelectedDate="2026-10-05"/>
```

### Fontos tulajdonságok

```text
SelectedDate
DisplayDate
DisplayDateStart
DisplayDateEnd
IsDropDownOpen
IsTodayHighlighted
```

C#:

```csharp
DateTime? datum = datePicker.SelectedDate;
```

---

# 25. Calendar

Teljes naptár megjelenítése.

```xml
<Calendar/>
```

### Fontos tulajdonságok

```text
SelectedDate
SelectedDates
DisplayDate
DisplayMode
SelectionMode
```

---

# 26. Expander

Összecsukható/kinyitható tartalom.

```xml
<Expander Header="Részletek">

    <TextBlock Text="További információ..."/>

</Expander>
```

### Fontos tulajdonságok

```text
Header
IsExpanded
ExpandDirection
```

Tipikus:

```text
▶ Részletek
```

majd:

```text
▼ Részletek
   további információk...
```

---

# 27. GroupBox

Vezérlők vizuális csoportosítása.

```xml
<GroupBox Header="Személyes adatok">

    <StackPanel>
        <TextBox/>
        <TextBox/>
    </StackPanel>

</GroupBox>
```

Eredmény koncepcionálisan:

```text
┌─ Személyes adatok ──────────┐
│                              │
│ Név:     [_______________]   │
│ Email:   [_______________]   │
│                              │
└──────────────────────────────┘
```

Fontos tulajdonság:

```text
Header
```

---

# 28. TabControl

Lapfüles felület készítésére.

```xml
<TabControl>

    <TabItem Header="Általános">
        <TextBlock Text="Általános beállítások"/>
    </TabItem>

    <TabItem Header="Hálózat">
        <TextBlock Text="Hálózati beállítások"/>
    </TabItem>

</TabControl>
```

Fontos tulajdonságok:

```text
Items
SelectedItem
SelectedIndex
TabStripPlacement
```

A `TabItem` legfontosabb saját tulajdonsága:

```text
Header
```

---

# 29. ScrollViewer

Görgethetővé teszi a tartalmát.

```xml
<ScrollViewer>

    <StackPanel>
        ...
    </StackPanel>

</ScrollViewer>
```

### Fontos tulajdonságok

```text
HorizontalScrollBarVisibility
VerticalScrollBarVisibility
CanContentScroll
```

Értékek:

```text
Disabled
Auto
Hidden
Visible
```

Gyakori:

```xml
<ScrollViewer VerticalScrollBarVisibility="Auto">
```

---

# 30. Menu

Klasszikus alkalmazásmenü.

```xml
<Menu>

    <MenuItem Header="_Fájl">
        <MenuItem Header="Megnyitás"/>
        <MenuItem Header="Mentés"/>
        <Separator/>
        <MenuItem Header="Kilépés"/>
    </MenuItem>

</Menu>
```

A `_` gyorsbillentyűt jelöl.

### MenuItem fontos tulajdonságai

```text
Header
Items
IsChecked
IsCheckable
Command
Icon
```

### Fontos esemény

```text
Click
```

---

# 31. Separator

Vizuális elválasztó:

```xml
<Separator/>
```

Például menüben:

```text
Megnyitás
Mentés
────────────
Kilépés
```

---

# 32. ToolBar

Gyakran használt műveletek gyors elérésére.

```xml
<ToolBar>

    <Button Content="Új"/>
    <Button Content="Mentés"/>
    <Separator/>
    <Button Content="Törlés"/>

</ToolBar>
```

Általában ikonokat tartalmazó gombokkal használjuk.

---

# 33. StatusBar

Az ablak alján állapotinformációk megjelenítésére.

```xml
<StatusBar>

    <StatusBarItem>
        <TextBlock Text="Kész"/>
    </StatusBarItem>

</StatusBar>
```

Például:

```text
-------------------------------------------------
Kész                     Sor: 15       UTF-8
-------------------------------------------------
```

---

# 34. Rectangle, Ellipse, Line és egyéb Shape-ek

A WPF közvetlenül támogat egyszerű vektorgrafikus objektumokat.

## Rectangle

```xml
<Rectangle Width="100"
           Height="50"
           Fill="Red"
           Stroke="Black"
           StrokeThickness="2"/>
```

## Ellipse

```xml
<Ellipse Width="100"
         Height="100"
         Fill="Blue"/>
```

Ha `Width == Height`, kör lesz.

## Line

```xml
<Line X1="0"
      Y1="0"
      X2="200"
      Y2="100"
      Stroke="Black"
      StrokeThickness="3"/>
```

### Shape-ek közös fontos tulajdonságai

```text
Fill
Stroke
StrokeThickness
StrokeDashArray
Stretch
```

Ezek különösen hasznosak játékok, grafikonok, diagramok és egyedi grafikus felületek készítésénél.

---

# 35. Window

Végül maga az alkalmazásablak:

```xml
<Window x:Class="MyApp.MainWindow"
        Title="Programom"
        Width="800"
        Height="600">

    <Grid>
        ...
    </Grid>

</Window>
```

### Fontosabb saját tulajdonságok

```text
Title
Icon
WindowState
WindowStyle
ResizeMode
SizeToContent
Topmost
ShowInTaskbar
WindowStartupLocation
```

Például:

```xml
WindowStartupLocation="CenterScreen"
```

Az ablak középen jelenik meg.

---

# Összefoglaló – mit érdemes elsőként megtanulni?

Ha WPF-et tanítasz, én nagyjából ebben a sorrendben vezetném be az elemeket:

| Csoport | Legfontosabb elemek | Mire használjuk? |
|---|---|---|
| **Ablak** | `Window` | alkalmazásablak |
| **Layout** | `Grid` | sor/oszlop alapú elrendezés |
| | `StackPanel` | egymás alá/mellé rendezés |
| | `WrapPanel` | automatikusan tördelődő elemek |
| | `DockPanel` | oldalakhoz rögzítés |
| | `Canvas` | koordináta alapú elhelyezés |
| **Struktúra** | `Border` | keret/háttér |
| | `GroupBox` | logikai csoport |
| | `ScrollViewer` | görgetés |
| | `TabControl` | füles felület |
| | `Expander` | lenyitható tartalom |
| **Szöveg** | `TextBlock` | szöveg megjelenítése |
| | `Label` | mező címkéje |
| **Bevitel** | `TextBox` | szövegbevitel |
| | `PasswordBox` | jelszó |
| | `CheckBox` | igen/nem |
| | `RadioButton` | egy választás több közül |
| | `Slider` | numerikus érték |
| | `DatePicker` | dátum |
| **Művelet** | `Button` | művelet indítása |
| **Listák** | `ComboBox` | legördülő lista |
| | `ListBox` | egyszerű lista |
| | `ListView` | strukturált lista |
| | `DataGrid` | táblázatos adatok |
| **Megjelenítés** | `Image` | kép |
| | `ProgressBar` | folyamatjelző |
| **Alkalmazás UI** | `Menu` | főmenü |
| | `ToolBar` | eszköztár |
| | `StatusBar` | állapotsor |
| **Grafika** | `Rectangle`, `Ellipse`, `Line` | vektorgrafika |

Egy **kezdő WPF tananyaghoz** szükséges legfontosabb alapot a `Grid`, `StackPanel`, `TextBlock`, `Button`, `TextBox`, `ComboBox`, `ListBox` és `DataGrid` biztosítja. Ezek után érdemes továbblépni az adatbinding, a stílusok, a sablonok és az MVVM felépítés felé.

