CREATE TABLE `sort`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(32) NULL,
  `init` VARCHAR(20) NULL,
  PRIMARY KEY (`id`));
CREATE TABLE `sort`.`scores` (
  `id` INT NOT NULL AUTO_INCREMENT,
`user` INT NOT NULL,
`score` INT NOT NULL,
`move` INT NOT NULL,
`time` INT NOT NULL,
`clear` INT NOT NULL,
`init` INT NOT NULL,
`mode` varchar(16),
  PRIMARY KEY (`id`));
CREATE TABLE `sort`.`times` (
`id` INT NOT NULL AUTO_INCREMENT,
`user` INT NOT NULL,
`game_start` INT NOT NULL,
`game_end` INT NOT NULL,
`app_start` INT NOT NULL,
  PRIMARY KEY (`id`));
