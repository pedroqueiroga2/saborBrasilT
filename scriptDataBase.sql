-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8mb4 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Usuario` (
  `idusuario` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(255) NULL,
  `CPF` VARCHAR(255) NOT NULL,
  `senha` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(11) NOT NULL,
  `email` VARCHAR(255) NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idusuario`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `mydb`.`Publicacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Publicacao` (
  `idpost` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `descricao` VARCHAR(255) NOT NULL,
  `Imagem` VARCHAR(255) NULL,
  `nomeProduto` VARCHAR(45) NULL,
  `UsuarioId` INT NULL,
  `dataPublicao` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idpost`),
  INDEX `UsuarioId_idx` (`UsuarioId` ASC) VISIBLE,
  CONSTRAINT `UsuarioId`
    FOREIGN KEY (`UsuarioId`)
    REFERENCES `mydb`.`Usuario` (`idusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `mydb`.`comentarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`comentarios` (
  `idcomentario` INT NOT NULL AUTO_INCREMENT,
  `descricao` TEXT NOT NULL,
  `id_usuario` INT NULL,
  `data` DATETIME NULL,
  `post_id` INT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idcomentario`),
  INDEX `id_usuario_idx` (`id_usuario` ASC) VISIBLE,
  INDEX `post_id_idx` (`post_id` ASC) VISIBLE,
  CONSTRAINT `id_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `mydb`.`Usuario` (`idusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `post_id`
    FOREIGN KEY (`post_id`)
    REFERENCES `mydb`.`Publicacao` (`idpost`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `mydb`.`likes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`likes` (
  `idlikes` INT NOT NULL AUTO_INCREMENT,
  `id_usuario` INT NOT NULL,
  `id_post` INT NOT NULL,
  PRIMARY KEY (`idlikes`),
  UNIQUE INDEX `unique_user_post` (`id_usuario` ASC, `id_post` ASC) VISIBLE,
  INDEX `id_post_idx` (`id_post` ASC) VISIBLE,
  CONSTRAINT `fk_likes_id_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `mydb`.`Usuario` (`idusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_likes_id_post`
    FOREIGN KEY (`id_post`)
    REFERENCES `mydb`.`Publicacao` (`idpost`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- Ajuste do campo CPF para varchar(255)
ALTER TABLE Usuario CHANGE COLUMN CPF cpf VARCHAR(255) NOT NULL;
select * from usuario;
drop database mydb;

