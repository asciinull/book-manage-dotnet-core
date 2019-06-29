CREATE TABLE `the_book` (
    `id` int NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `title` varchar(100) NULL COMMENT 'Title',
    `category_ids` varchar(100) NULL COMMENT 'CategoryIds',
    `color_id` int NOT NULL DEFAULT 0 COMMENT 'ColorId',
    `data_status` int NOT NULL DEFAULT 0 COMMENT 'DataStatus',
    `create_time` datetime NOT NULL COMMENT 'CreateTime',
    `last_update_time` datetime NOT NULL COMMENT 'LastUpdateTime',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8mb4 COMMENT='TheBook';

CREATE TABLE `category` (
    `id` int NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `name` varchar(100) NULL COMMENT 'Name',
    `description` varchar(100) NULL COMMENT 'Description',
    `data_status` int NOT NULL DEFAULT 0 COMMENT 'DataStatus',
    `create_time` datetime NOT NULL COMMENT 'CreateTime',
    `last_update_time` datetime NOT NULL COMMENT 'LastUpdateTime',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8mb4 COMMENT='Category';

CREATE TABLE `color` (
    `id` int NOT NULL AUTO_INCREMENT COMMENT 'Id',
    `color_id` int NOT NULL DEFAULT 0 COMMENT 'ColorId',
    `color_name` varchar(100) NULL COMMENT 'ColorName',
    `data_status` int NOT NULL DEFAULT 0 COMMENT 'DataStatus',
    `create_time` datetime NOT NULL COMMENT 'CreateTime',
    `last_update_time` datetime NOT NULL COMMENT 'LastUpdateTime',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8mb4 COMMENT='Color';

