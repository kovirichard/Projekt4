-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Már 30. 19:41
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

CREATE DATABASE parkolokezelo
DEFAULT CHARACTER SET utf8
COLLATE utf8_hungarian_ci;

USE parkolokezelo;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `esemeny`
--

CREATE TABLE `esemeny` (
  `id` int(11) NOT NULL,
  `rendszam` varchar(16) NOT NULL,
  `parkolas_kezdete` datetime NOT NULL,
  `parkolas_vege` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jarmu`
--

CREATE TABLE `jarmu` (
  `rendszam` varchar(16) NOT NULL,
  `tipus` varchar(20) NOT NULL,
  `mozgaskorlatozott` bit(1) NOT NULL,
  `elektromos` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `parkolo`
--

CREATE TABLE `parkolo` (
  `sor` int(11) NOT NULL,
  `oszlop` int(11) NOT NULL,
  `tipus` varchar(50) NOT NULL DEFAULT 'normal',
  `jarmu_rendszam` varchar(16) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `parkolo`
--

INSERT INTO `parkolo` (`sor`, `oszlop`, `tipus`, `jarmu_rendszam`) VALUES
(0, 0, 'elektromos', NULL),
(0, 1, 'elektromos', NULL),
(0, 2, 'normal', NULL),
(0, 3, 'normal', NULL),
(0, 4, 'normal', NULL),
(0, 5, 'normal', NULL),
(0, 6, 'normal', NULL),
(0, 7, 'normal', NULL),
(1, 0, 'elektromos', NULL),
(1, 1, 'elektromos', NULL),
(1, 2, 'normal', NULL),
(1, 3, 'normal', NULL),
(1, 4, 'normal', NULL),
(1, 5, 'normal', NULL),
(1, 6, 'normal', NULL),
(1, 7, 'normal', NULL),
(2, 0, 'normal', NULL),
(2, 1, 'normal', NULL),
(2, 2, 'normal', NULL),
(2, 3, 'normal', NULL),
(2, 4, 'normal', NULL),
(2, 5, 'normal', NULL),
(2, 6, 'mozgasserult', NULL),
(2, 7, 'mozgasserult', NULL),
(3, 0, 'normal', NULL),
(3, 1, 'normal', NULL),
(3, 2, 'normal', NULL),
(3, 3, 'normal', NULL),
(3, 4, 'normal', NULL),
(3, 5, 'normal', NULL),
(3, 6, 'mozgasserult', NULL),
(3, 7, 'mozgasserult', NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tranzakcio`
--

CREATE TABLE `tranzakcio` (
  `id` int(11) NOT NULL,
  `rendszam` varchar(16) NOT NULL,
  `osszeg` decimal(10,2) NOT NULL,
  `datum` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `esemeny`
--
ALTER TABLE `esemeny`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_parkolas_kezdete` (`parkolas_kezdete`),
  ADD KEY `idx_parkolas_vege` (`parkolas_vege`),
  ADD KEY `fk_esemenyek_rendszam` (`rendszam`);

--
-- A tábla indexei `jarmu`
--
ALTER TABLE `jarmu`
  ADD PRIMARY KEY (`rendszam`);

--
-- A tábla indexei `parkolo`
--
ALTER TABLE `parkolo`
  ADD PRIMARY KEY (`sor`,`oszlop`),
  ADD KEY `fk_parkolok_jarmu_rendszam` (`jarmu_rendszam`);

--
-- A tábla indexei `tranzakcio`
--
ALTER TABLE `tranzakcio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_datum` (`datum`),
  ADD KEY `fk_tranzakciok_rendszam` (`rendszam`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `esemeny`
--
ALTER TABLE `esemeny`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `tranzakcio`
--
ALTER TABLE `tranzakcio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `esemeny`
--
ALTER TABLE `esemeny`
  ADD CONSTRAINT `fk_esemenyek_rendszam` FOREIGN KEY (`rendszam`) REFERENCES `jarmu` (`rendszam`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `parkolo`
--
ALTER TABLE `parkolo`
  ADD CONSTRAINT `fk_parkolok_jarmu_rendszam` FOREIGN KEY (`jarmu_rendszam`) REFERENCES `jarmu` (`rendszam`) ON DELETE SET NULL ON UPDATE NO ACTION;

--
-- Megkötések a táblához `tranzakcio`
--
ALTER TABLE `tranzakcio`
  ADD CONSTRAINT `fk_tranzakciok_rendszam` FOREIGN KEY (`rendszam`) REFERENCES `jarmu` (`rendszam`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
