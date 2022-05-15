-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3308
-- Généré le :  jeu. 31 mars 2022 à 15:18
-- Version du serveur :  8.0.18
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `eoliennedb`
--

-- --------------------------------------------------------

--
-- Structure de la table `eolienne`
--

DROP TABLE IF EXISTS `eolienne`;
CREATE TABLE IF NOT EXISTS `eolienne` (
  `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `eolienne`
--

INSERT INTO `eolienne` (`id`, `nom`) VALUES
(1, 'Air BREAZE');

-- --------------------------------------------------------

--
-- Structure de la table `periode`
--

DROP TABLE IF EXISTS `periode`;
CREATE TABLE IF NOT EXISTS `periode` (
  `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `duree` int(11) NOT NULL,
  `puissance_soufflerie` int(11) NOT NULL,
  `scenario_id` int(11) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_eolienne_idx` (`scenario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `periode`
--

INSERT INTO `periode` (`id`, `duree`, `puissance_soufflerie`, `scenario_id`) VALUES
(1, 20, 10, 1),
(2, 20, 20, 1),
(3, 20, 30, 1),
(4, 20, 60, 1),
(5, 40, 80, 1),
(6, 60, 100, 1),
(7, 20, 50, 1),
(8, 20, 40, 1),
(11, 20, 10, 2),
(12, 20, 15, 2),
(13, 20, 20, 2),
(14, 20, 25, 2),
(15, 20, 30, 2),
(16, 20, 30, 2),
(17, 20, 25, 2),
(18, 20, 20, 2),
(19, 20, 15, 2),
(20, 20, 10, 2);

-- --------------------------------------------------------

--
-- Structure de la table `releve`
--

DROP TABLE IF EXISTS `releve`;
CREATE TABLE IF NOT EXISTS `releve` (
  `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `test_id` int(11) UNSIGNED NOT NULL,
  `date_heure` datetime NOT NULL,
  `puissance_eolienne` varchar(45) DEFAULT NULL,
  `force_vent` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_releve_test1_idx` (`test_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `releve`
--

INSERT INTO `releve` (`id`, `test_id`, `date_heure`, `puissance_eolienne`, `force_vent`) VALUES
(1, 1, '2022-03-24 14:20:10', '120', '20'),
(2, 1, '2022-03-24 14:20:20', '120', '20'),
(3, 1, '2022-03-24 14:20:30', '145', '32'),
(4, 1, '2022-03-24 14:20:40', '160', '37');

-- --------------------------------------------------------

--
-- Structure de la table `scenario`
--

DROP TABLE IF EXISTS `scenario`;
CREATE TABLE IF NOT EXISTS `scenario` (
  `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `date_creation` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `scenario`
--

INSERT INTO `scenario` (`id`, `nom`, `date_creation`) VALUES
(1, 'Bon temps', '2022-03-09 00:00:00'),
(2, 'Perturbation', '2022-03-22 00:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `test`
--

DROP TABLE IF EXISTS `test`;
CREATE TABLE IF NOT EXISTS `test` (
  `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `date_heure` datetime NOT NULL,
  `scenario_id` int(11) UNSIGNED NOT NULL,
  `eolienne_id` int(11) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_test_scenario_idx` (`scenario_id`),
  KEY `fk_test_eolienne_idx` (`eolienne_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `test`
--

INSERT INTO `test` (`id`, `date_heure`, `scenario_id`, `eolienne_id`) VALUES
(1, '2022-03-24 14:26:05', 1, 1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `periode`
--
ALTER TABLE `periode`
  ADD CONSTRAINT `fk_periode_scenario1` FOREIGN KEY (`scenario_id`) REFERENCES `scenario` (`id`);

--
-- Contraintes pour la table `releve`
--
ALTER TABLE `releve`
  ADD CONSTRAINT `fk_releve_test1` FOREIGN KEY (`test_id`) REFERENCES `test` (`id`);

--
-- Contraintes pour la table `test`
--
ALTER TABLE `test`
  ADD CONSTRAINT `fk_test_eolienne1` FOREIGN KEY (`eolienne_id`) REFERENCES `eolienne` (`id`),
  ADD CONSTRAINT `fk_test_scenario1` FOREIGN KEY (`scenario_id`) REFERENCES `scenario` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
