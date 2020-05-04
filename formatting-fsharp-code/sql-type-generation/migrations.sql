CREATE DATABASE twitter;
GO

USE twitter
CREATE TABLE users
(
    id   INT IDENTITY (1,1) PRIMARY KEY,
    name VARCHAR(50)
);
CREATE TABLE tweets
(
    id      INT IDENTITY (1,1) PRIMARY KEY,
    user_id INT,
    content VARCHAR(140)
);

ALTER TABLE tweets
    ADD CONSTRAINT fk_user
        FOREIGN KEY (user_id) REFERENCES users (id);

INSERT INTO users(name) values('@candace.larkin3');
DECLARE @user_0 INT;
SELECT @user_0 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_0, 'Laborum odit laboriosam enim minus qui consequuntur molestiae officiis eos.'),
                                             (@user_0, 'Delectus quis dolorem.'),
                                             (@user_0, 'Rerum ab autem deleniti.'),
                                             (@user_0, 'Sint vitae ex reiciendis incidunt eum modi.'),
                                             (@user_0, 'Blanditiis molestias recusandae esse.'),
                                             (@user_0, 'Eveniet minus ea aut quisquam.'),
                                             (@user_0, 'Quia ad voluptates deserunt commodi omnis pariatur odit.'),
                                             (@user_0, 'Sit quo qui sequi.'),
                                             (@user_0, 'Est qui provident.'),
                                             (@user_0, 'Commodi eaque aliquid tempora ut totam commodi quia harum.');

INSERT INTO users(name) values('@palma.collins54');
DECLARE @user_1 INT;
SELECT @user_1 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_1, 'Iure iusto temporibus recusandae voluptas optio ad corporis.'),
                                             (@user_1, 'Quos asperiores nihil vel minima perferendis saepe.'),
                                             (@user_1, 'Aut omnis eum qui ducimus sed et.'),
                                             (@user_1, 'Soluta voluptas reiciendis autem dignissimos tempora nesciunt et.'),
                                             (@user_1, 'Porro est perspiciatis et.'),
                                             (@user_1, 'Praesentium possimus quam.'),
                                             (@user_1, 'Eaque omnis earum expedita architecto non aut pariatur magnam.'),
                                             (@user_1, 'Magnam quasi earum ut dolores quis.'),
                                             (@user_1, 'Quis exercitationem non neque ut fugiat et amet.'),
                                             (@user_1, 'Labore ut porro ipsa voluptatem fuga dolorem.');

INSERT INTO users(name) values('@ryan77');
DECLARE @user_2 INT;
SELECT @user_2 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_2, 'Neque saepe nihil accusantium aliquam voluptas commodi.'),
                                             (@user_2, 'Aut minus tempore consequuntur est ut voluptate.'),
                                             (@user_2, 'Nihil sunt laudantium corrupti soluta est molestiae.'),
                                             (@user_2, 'Rem excepturi aut nam dolores non.'),
                                             (@user_2, 'Et et laboriosam.'),
                                             (@user_2, 'Et qui dolorum.'),
                                             (@user_2, 'Provident error sunt.'),
                                             (@user_2, 'Aut eum inventore temporibus cumque.'),
                                             (@user_2, 'Aspernatur et incidunt nesciunt cum et iure delectus voluptatem iste.'),
                                             (@user_2, 'Autem cumque praesentium omnis fuga ipsa modi et.');

INSERT INTO users(name) values('@leanne95');
DECLARE @user_3 INT;
SELECT @user_3 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_3, 'Dolorem doloremque aut aut recusandae et.'),
                                             (@user_3, 'Deleniti dolorem est.'),
                                             (@user_3, 'Quisquam enim est aperiam deserunt debitis.'),
                                             (@user_3, 'Tempora esse nobis ad voluptatem et.'),
                                             (@user_3, 'Id et fugit provident deleniti.'),
                                             (@user_3, 'Quo ex ut assumenda quasi vel quaerat tempora facere.'),
                                             (@user_3, 'Voluptates qui et qui sit occaecati aut nihil ipsum.'),
                                             (@user_3, 'In asperiores sit repellendus saepe impedit quod animi.'),
                                             (@user_3, 'Inventore asperiores hic ut.'),
                                             (@user_3, 'Sunt consequatur eaque a delectus omnis dolorum labore rem.');

INSERT INTO users(name) values('@jake_walter');
DECLARE @user_4 INT;
SELECT @user_4 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_4, 'Est dolores libero et ex numquam necessitatibus.'),
                                             (@user_4, 'Ea minus non voluptas laboriosam ducimus debitis ea.'),
                                             (@user_4, 'Distinctio aperiam optio.'),
                                             (@user_4, 'A autem eum similique et atque sit praesentium reprehenderit.'),
                                             (@user_4, 'Laboriosam cupiditate esse aut.'),
                                             (@user_4, 'Ipsa illum et reiciendis dolorem nemo deserunt laborum laborum.'),
                                             (@user_4, 'Accusantium officia vitae id impedit a sed omnis.'),
                                             (@user_4, 'Illum laboriosam quo ex cumque minus officiis tempora delectus.'),
                                             (@user_4, 'Officiis voluptatem molestiae odio fugit ipsam aliquam.'),
                                             (@user_4, 'Illo provident sint consequatur sit eius.');

INSERT INTO users(name) values('@fabiola_langworth');
DECLARE @user_5 INT;
SELECT @user_5 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_5, 'Et saepe itaque at nobis dolorem dolores maxime quidem.'),
                                             (@user_5, 'Quam quia laudantium perspiciatis.'),
                                             (@user_5, 'Nostrum beatae fuga alias.'),
                                             (@user_5, 'Velit aut voluptatem delectus quis qui perspiciatis ratione.'),
                                             (@user_5, 'Voluptatem ducimus nesciunt et.'),
                                             (@user_5, 'Quasi quo itaque quis veniam dignissimos quod.'),
                                             (@user_5, 'Nostrum et optio aut temporibus accusamus consequatur.'),
                                             (@user_5, 'Iusto maxime dolor atque.'),
                                             (@user_5, 'Non maxime ut error incidunt dolorum.'),
                                             (@user_5, 'Et quis placeat voluptatem deserunt hic rem velit aliquid nihil.');

INSERT INTO users(name) values('@hank_okon');
DECLARE @user_6 INT;
SELECT @user_6 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_6, 'Natus repellat quo consequatur et.'),
                                             (@user_6, 'Dolor nam tempore laboriosam consequatur.'),
                                             (@user_6, 'Cumque voluptatibus magni explicabo perspiciatis sunt delectus consequatur ab.'),
                                             (@user_6, 'Facere architecto sint dolores et occaecati voluptas in in.'),
                                             (@user_6, 'Minus ea et corrupti qui porro voluptas cumque iure similique.'),
                                             (@user_6, 'Est quos perspiciatis quae veniam praesentium at non voluptatem eum.'),
                                             (@user_6, 'Nostrum id et voluptas saepe voluptate fugiat distinctio dolorem ad.'),
                                             (@user_6, 'Quia explicabo ullam commodi facilis molestias dolorem dolore voluptatem nihil.'),
                                             (@user_6, 'Officiis odit qui autem qui voluptatem.'),
                                             (@user_6, 'Maiores totam beatae.');

INSERT INTO users(name) values('@jamar_kuvalis');
DECLARE @user_7 INT;
SELECT @user_7 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_7, 'Quo fugit debitis dolore qui dolorem iusto.'),
                                             (@user_7, 'Est quod cum impedit quis ducimus placeat sint vel.'),
                                             (@user_7, 'Aut quasi quia voluptatum aut.'),
                                             (@user_7, 'Dolores dolor sint a nobis animi quo aut eos.'),
                                             (@user_7, 'Quaerat sit atque in nobis alias vel.'),
                                             (@user_7, 'Optio quod velit in numquam non.'),
                                             (@user_7, 'Incidunt dolore rerum consequatur consequatur vel ea enim.'),
                                             (@user_7, 'Aut facilis enim.'),
                                             (@user_7, 'Sit quia et accusamus pariatur placeat.'),
                                             (@user_7, 'Error iusto velit distinctio.');

INSERT INTO users(name) values('@giovanni_hodkiewicz');
DECLARE @user_8 INT;
SELECT @user_8 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_8, 'Quaerat est omnis.'),
                                             (@user_8, 'Libero id delectus.'),
                                             (@user_8, 'Aliquam qui ex adipisci odio at et.'),
                                             (@user_8, 'Officiis totam quis ipsa eligendi suscipit non in quo voluptas.'),
                                             (@user_8, 'Totam quod eos quibusdam fugiat voluptatibus voluptatem.'),
                                             (@user_8, 'Expedita qui dolore ut autem cum est modi.'),
                                             (@user_8, 'Assumenda impedit et asperiores molestias quis eligendi delectus.'),
                                             (@user_8, 'Et velit et.'),
                                             (@user_8, 'Sed tempora nisi sit et voluptas fugit.'),
                                             (@user_8, 'Occaecati numquam quia odit qui ipsam et quia.');

INSERT INTO users(name) values('@isaac.lehner');
DECLARE @user_9 INT;
SELECT @user_9 = @@Identity;
INSERT INTO tweets (user_id, content) values (@user_9, 'Commodi delectus fugit deleniti consequatur magni saepe iste a blanditiis.'),
                                             (@user_9, 'Eum impedit consequatur at eum qui.'),
                                             (@user_9, 'Sit consequatur consectetur dolor aut aut.'),
                                             (@user_9, 'Dolore quos aliquam.'),
                                             (@user_9, 'Et aut et voluptas non magnam dignissimos consequatur aperiam qui.'),
                                             (@user_9, 'Ducimus et ut.'),
                                             (@user_9, 'Libero dolorem vel pariatur quia ad.'),
                                             (@user_9, 'Recusandae est sed quisquam sit dicta.'),
                                             (@user_9, 'In natus quidem.'),
                                             (@user_9, 'Libero eaque deleniti vel maiores dolores fugit voluptate.');

