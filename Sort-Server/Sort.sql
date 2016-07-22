CREATE TABLE `sort`.`users` (
	  `id` INT NOT NULL AUTO_INCREMENT,
	  `user` VARCHAR(32) NULL,
	  `init` VARCHAR(20) NULL,
  PRIMARY KEY (`id`));
CREATE TABLE `sort`.`scores` (
  	`id` INT NOT NULL AUTO_INCREMENT,
	`user` INT NOT NULL,
	`score` INT NOT NULL,
	`move` INT NOT NULL,
	`time` INT NOT NULL,
	`clear` INT NOT NULL,
	`init` varchar(20) NOT NULL,
	`mode` varchar(16),
  PRIMARY KEY (`id`));
CREATE TABLE `sort`.`times` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`user` INT NOT NULL,
	`game_start` varchar(20) NOT NULL,
	`game_end` varchar(20) NOT NULL,
	`app_start` varchar(20) NOT NULL,
  PRIMARY KEY (`id`));
CREATE TABLE `sort`.`guests` (
	`name` varchar(32) NOT NULL
);
