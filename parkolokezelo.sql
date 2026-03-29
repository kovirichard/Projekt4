-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Már 29. 22:01
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `parkolokezelo`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `esemenyek`
--

CREATE TABLE `esemenyek` (
  `id` int(11) NOT NULL,
  `rendszam` varchar(16) NOT NULL,
  `parkolas_kezdete` datetime NOT NULL,
  `parkolas_vege` datetime NOT NULL DEFAULT '9999-12-31 23:59:59'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jarmuvek`
--

CREATE TABLE `jarmuvek` (
  `rendszam` varchar(16) NOT NULL,
  `tipus` varchar(20) NOT NULL,
  `mozgaskorlatozott` bit(1) NOT NULL,
  `elektromos` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `parkolok`
--

CREATE TABLE `parkolok` (
  `sor` int(11) NOT NULL,
  `oszlop` int(11) NOT NULL,
  `tipus` varchar(50) NOT NULL DEFAULT 'normal',
  `foglalt` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tranzakciok`
--

CREATE TABLE `tranzakciok` (
  `id` int(11) NOT NULL,
  `rendszam` varchar(16) NOT NULL,
  `osszeg` double NOT NULL,
  `datum` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `esemenyek`
--
ALTER TABLE `esemenyek`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `jarmuvek`
--
ALTER TABLE `jarmuvek`
  ADD PRIMARY KEY (`rendszam`);

--
-- A tábla indexei `parkolok`
--
ALTER TABLE `parkolok`
  ADD PRIMARY KEY (`sor`,`oszlop`);

--
-- A tábla indexei `tranzakciok`
--
ALTER TABLE `tranzakciok`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `esemenyek`
--
ALTER TABLE `esemenyek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `tranzakciok`
--
ALTER TABLE `tranzakciok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
