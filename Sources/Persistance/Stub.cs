using Modele;

namespace StubFile
{
    public class Stub : ILoadable
    { 
        public Application Application { get; set; } = new Application();

        public Stub() 
        {
            
        }

        
        public Application Load()
        {
            Application application = Application;
            Ingredient soupeI = new Ingredient("chou", 1, "");
            Ingredient soupeI2 = new Ingredient("carottes", 12, "");
            Ingredient soupeI3 = new Ingredient("patates", 3, "kg");
            Ingredient soupeI4 = new Ingredient("eau", 30, "cl");
            Recipe Soupe = new Recipe("Soupe", Category.Plat, "soupe", "Facile", new List<Ingredient>(), 
                                      "Mixer le tout une fois cuit au bout de 20 minutes", 20, 1, new List<Rating>(),"");
            Soupe.AddIngs(soupeI);
            Soupe.AddIngs(soupeI2);
            Soupe.AddIngs(soupeI3);
            Soupe.AddIngs(soupeI4);

            Recipe sandwich = new Recipe("salé", Category.PetiteFaim,
                                       "sandwich jambon beurre", "facile",
                                       new List<Ingredient>(),
                                       "ajouter le beurre puis le jambon au pain préalablement coupé en deux",
                                       5, 1, new List<Rating>(),"");
            Ingredient pain = new Ingredient("pain", 1, "");
            Ingredient beurre = new Ingredient("beurre", 5, "g");
            Ingredient jambon = new Ingredient("jambon", 3, "tranches");
            Ingredient[] ings = { pain, beurre, jambon };
            sandwich.AddIngs(ings);

            Ingredient tarteI = new Ingredient("pommes", 5, "");
            Ingredient tarteI2 = new Ingredient("pate feuilletée", 1, "");
            Ingredient tarteI3 = new Ingredient("sucre", 90, "g");
            Ingredient tarteI4 = new Ingredient("oeufs", 2, "");
            Ingredient tarteI5 = new Ingredient("beurre", 60, "g");
            Recipe TartePommes = new Recipe("gâteaux", Category.Dessert, "Tarte aux pommes", "Facile", new List<Ingredient>(), "coupez les pommes en morceaux.\n Faites fondre le beurre dans une casserole.\n" +
                "Dans un saladier, mélangez les oeufs, le sucre et le beurre fondu.\n Etalez la pate dans un moule et disposez y les morceaux de pommes\n Ajoutez ensuite le beurre, les oeufs et le sucre.\n" +
                "Faites cuire a 200° (thermostat 7) pendant 30 min", 30, 1, new List<Rating>(), "");
            TartePommes.AddIngs(tarteI);
            TartePommes.AddIngs(tarteI2);
            TartePommes.AddIngs(tarteI3);
            TartePommes.AddIngs(tarteI4);
            TartePommes.AddIngs(tarteI5);


            Recipe cookiefondant = new Recipe("viennoiseries", Category.PetiteFaim, "Cookies coeur fondant", "Facile", new List<Ingredient>(), "Dans un récipient mélangez le beurre " +
                " ramolli ainsi que le sucre et les oeufs.\n Une fois que vous avez obtenu un mélange homogène, ajoutez la farine et la levure. \n Ajoutez les pépites et laissez poser quelques" +
                " instants dans une zone réfrigérée. \n Il ne vous reste plus qu'à en faire des petites boules et y ajouter un ou deux carreaux de chocolat au centre puis les disposer sur " +
                " votre plaque pour les faire cuire au four à 180°C pendant 12 minutes maximum.", 90, 1, new List<Rating>(), "cookies.jpg");

            Ingredient c_beurre = new Ingredient("beurre", 120, "g");
            Ingredient c_sucre = new Ingredient("sucre", 100, "g");
            Ingredient c_oeuf = new Ingredient("oeuf", 1, "");
            Ingredient c_farine = new Ingredient("farine", 220, "g");
            Ingredient c_levure = new Ingredient("levure", 1, "demi sachet");
            Ingredient c_pepites = new Ingredient("pépites de chocolat", 200, "g");

            Ingredient[] ings_cookies = { c_beurre, c_farine, c_levure, c_oeuf, c_pepites, c_sucre };
            cookiefondant.AddIngs(ings_cookies);

            Recipe gaufre = new Recipe("viennoiseries", Category.PetiteFaim, "Gaufres", "Facile", new List<Ingredient>(), "Dans un saladier," +
                " ajouter le beurre ramolli, les jaunes d'oeufs (séparés des blancs au préablable) ainsi que le sucre.\n Ajouter le lait en le versant" +
                " petit à petit pour éviter la formation de grumeaux.\n Battre les blancs en neige en y ajoutant une pincée de sel puis un fois montés, " +
                " incorporer délicatement au mélange.\n Cuire le tout pendant 5 minutes dans un gaufrier légèrement beurré.", 15, 1, new List<Rating>(), "gaufres.jpg");
            Ingredient g_beurre = new Ingredient("beurre", 20, "g");
            Ingredient g_sucre = new Ingredient("sucre", 30, "g");
            Ingredient g_oeuf = new Ingredient("oeufs", 3, "");
            Ingredient g_farine = new Ingredient("farine", 200, "g");
            Ingredient g_lait = new Ingredient("lait", 25, "cL");
            Ingredient g_sel = new Ingredient("sel", 1, "pincée");

            Ingredient[] ings_gaufre = { g_beurre,g_farine, g_lait, g_sel, g_oeuf, g_sucre };
            gaufre.AddIngs(ings_gaufre);


            Recipe moelleux = new Recipe("gâteaux", Category.Dessert, "Moelleux au chocolat", "Facile", new List<Ingredient>(), "Dans un " +
                " premier temps, faire fondre le chocolat au bain marie ou au micro-ondes selon votre préférence. \n Une fois que le chocolat" +
                " est bien fondu, y ajouter peu à peu le beurre en morceaux afin d'obtenir une crème bien lisse.\n Dans un second récipient," +
                " mélanger la farine, le sucre glace, puis y ajouter les oeufs jusqu'à obtenir une pâte homogène.\n Verser ensuite le premier mélange dans " +
                " celui-ci puis mélanger jusqu'à obtenir un appareil lisse.\n Beurrer puis fariner le moule de votre gâteau et y verser la préparatin.\n" +
                "Enfourner 12 minutes à 200°C et c'est prêt !\n Pour obtenir un coeur coulant, laissez plutôt cuire 9 minutes, à servir tiède avec de la" +
                " crème anglaise ou une boule de glace vaille.", 27, 2, new List<Rating>(), "moelleux.jpg");

            Ingredient m_beurre = new Ingredient("beurre", 175, "g");
            Ingredient m_sucre = new Ingredient("sucre glace", 125, "g");
            Ingredient m_oeuf = new Ingredient("oeufs", 5, "");
            Ingredient m_farine = new Ingredient("farine", 75, "g");
            Ingredient m_chocolat = new Ingredient("chocolat", 250, "g");

            Ingredient[] ings_moelleux = { m_beurre, m_sucre, m_chocolat, m_farine, m_oeuf };
            moelleux.AddIngs(ings_moelleux);


            Recipe chouquettes = new Recipe("Viennoiseries", Category.PetiteFaim, "Chouquettes", "Facile", new List<Ingredient>(), "Dans une " +
                "casserole, porter à ébulition l'eau et le beurre. \n Lorsque le mélange bout, retirer la casserole du feu et ajouter au mélange" +
                " la farine, le sel et la levure.\n A l'aide d'une spatule mélanger jusqu'à ce que l'appareil se décolle de la casserole.\n Après" +
                " avoir laissé refroidir quelques instants, ajouter le sucre et un oeuf et fouetter énergiquement.\n Une fois les ingrédients " +
                "incorporés, recommncer avec les 2 autres oeufs.\n Sur une plaque, faire des petites boules avec des cuillères et les saupoudrer " +
                "de grains de gros sucre avant d'enfourner pour 17 minutes à 210°C.", 35, 1, new List<Rating>(), "chouquettes.jpg");

            Ingredient ch_eau = new Ingredient("eau", 25, "cL");
            Ingredient ch_beurre = new Ingredient("beurre doux", 100, "g");
            Ingredient ch_farine = new Ingredient("farine", 150, "g");
            Ingredient ch_sucre = new Ingredient("sucre vanillé", 1, "sachet");
            Ingredient ch_sel = new Ingredient("sel", 1, "CàC");
            Ingredient ch_levure = new Ingredient("levure", 1, "CàC");
            Ingredient ch_oeufs = new Ingredient("oeufs", 3, "");

            Ingredient[] ings_chouq = { ch_beurre, ch_eau, ch_farine, ch_sucre, ch_sel, ch_levure, ch_oeufs };
            chouquettes.AddIngs(ings_chouq);


            Recipe chaussonPommes = new Recipe("Viennoiseries", Category.PetiteFaim, "Chausson Pommes", "Facile", new List<Ingredient>(),
                "Préparez les pommes afin d'obtenir des tranches à mettre à cuire dans une casserole avec le sucre, la vanille," +
                " la cannelle, le sel et l'eau.\nPour caraméliser la compote, laissez la cuire 15 minutes puis laissez refroidir " +
                "en dehors du feu.\nSur le plan de travail, déroulez la pâte feuilletée et à l'aide d'un emporte-pièce, découpez" +
                " des cercles de pâte.\nDéposez délicatement vos cercles sur une plaque de cuisson et à leur centre, placez-y deux " +
                "cuillères à soupe de compote.\nBattez l'oeuf entier dans un petit bol puis badigeonnez les contours des cercles " +
                "avec, ce qui servira de 'colle' pour les chaussons.\nPuis, ajouter un peu de sucre glace au reste d'oeuf et " +
                "appliquez ce mélange sur les chausson fermés afin de les faire dorer.\n Enfournez 28 minutes à 170°C.\n", 
                45, 3, new List<Rating>(), "chaussons.jpg");

            Ingredient cp_pommes = new Ingredient("pommes", 4, "");
            Ingredient cp_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient cp_beurre = new Ingredient("beurre", 20, "g");
            Ingredient cp_sucre = new Ingredient("sucre roux", 20, "g");
            Ingredient cp_oeuf = new Ingredient("oeuf", 1, "");
            Ingredient cp_cannelle = new Ingredient("cannelle", 1, "pincée");
            Ingredient cp_sucreG = new Ingredient("sucre glace", 1, "CàC");

            Ingredient[] ings_chausson = {cp_beurre, cp_cannelle, cp_sucreG, cp_oeuf, cp_pate, cp_pommes, cp_sucre};
            chaussonPommes.AddIngs(ings_chausson);


            Recipe roules_th = new Recipe("roulés", Category.Entree, "Roulés tomate herbes", "Facile", new List<Ingredient>(),
                "Sur la pâte feuilletée, étalez uniformément le concentré de tomates puis le gruyère râpé et les herbes. \n Roulez la pâte feuilletée" +
                "jusqu'à arriver à la moitié puis recommencez de l'autre côté. \n Après l'avoir laissé reposer au congélateur pendant" +
                "10 minutes, coupez le tout en tranches et placez les sur une plaque de cuisson.\n Enfournez pour 10 minutes à 180°C.", 
                25,2,new List<Rating>(), "roules.jpg");

            Ingredient ro_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient ro_gruyere = new Ingredient("gruyère râpé", 70, "g");
            Ingredient ro_concentre = new Ingredient("concentré de tomates", 2, "boîtes");
            Ingredient ro_herbes = new Ingredient("herbes de provence", 2, "pincées");

            Ingredient[] ings_roules = { ro_concentre, ro_gruyere, ro_herbes, ro_pate };
            roules_th.AddIngs(ings_roules);

            Recipe roules_saucisse = new Recipe("roulés", Category.Entree, "Roulés saucisse", "Facile", new List<Ingredient>(),
                "Sur la pâte feuilletée, découpez des triangles de 3 cm de base. \n Etalez-y ensuite la moutarde à l'aide d'une cuillère" +
                " ou d'un pinceau.\n Ajoutez à chaque triangle, une saucisse cocktail et enroulez la pâte autour.\n Enfournez pour 15 minutes " +
                "à 220°C.", 30, 1, new List<Rating>(), "roules_s.jpg");

            Ingredient rs_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient rs_saucisses = new Ingredient("saucisses cocktail", 200, "g");
            Ingredient rs_moutarde = new Ingredient("moutarde", 2, "cuillères");

            Ingredient[] ings_rs = {rs_moutarde,rs_saucisses, rs_pate};
            roules_saucisse.AddIngs(ings_rs);

            Recipe torsades = new Recipe("feuilletés", Category.Aperitifs, "Torsades parmesan pavot", "Facile", new List<Ingredient>(),
                "Après avoir déroulé la pâte sur une surface plane, dans un bol, mélangez la moutarde, le paprika, le sel et les graines" +
                " de pavot.\n Répartissez le mélange ainsi que le parmesan sur la pâte puis coupez la en lamelles. Torsadez ces lamelles et appliquez du jaune" +
                " d'oeuf au besoin pour la dorure et les graines de pavot avant d'enfourner pour 15 minutes à 200°C.", 30, 3, new List<Rating>(), "torsades.jpg");


            Ingredient t_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient t_parmesan = new Ingredient("parmesan", 1, "demi sachet");
            Ingredient t_paprika = new Ingredient("paprika", 1, "pincée");
            Ingredient t_oeuf = new Ingredient("oeuf", 1, "");
            Ingredient t_sel = new Ingredient("sel", 1, "pincée");
            Ingredient t_graines = new Ingredient("graines de pavot", 2, "cuillères");

            Ingredient[] ings_torsades = {t_graines, t_oeuf, t_paprika, t_paprika, t_pate, t_parmesan, t_sel};
            torsades.AddIngs(ings_torsades);

            Recipe croissants = new Recipe("feuilletés", Category.Aperitifs, "Croissants jambon cru cantal", "Intermédiaire",new List<Ingredient>(),
                "Épluchez et hachez l’oignon rouge puis épluchez et coupez les tomates en dés.\nPlacez-les dans une poêle et faites-les cuire pendant" +
                " une dizaine de minutes.\n Ajoutez y l’huile d’olive, le miel, la gousse d’ail et l’oignon rouge puis laissez refroidir.\n" +
                " Déroulez ensuite la pâte et coupez-la en 8 parts égales. Répartissez sur chaque part des lamelles de cantal et une demi-tranche de " +
                "jambon de Bayonne.\n Roulez-les en croissants du bord vers le centre. A l’aide d’un pinceau, badigeonnez les croissants de jaune d’œuf dilué " +
                "au préalable dans un peu d’eau.\n Enfournez ensuite à 200°C pendant 15 minutes puis servez avec la purée de tomates.", 40,3,
                new List<Rating>(), "croissants.jpg");

            Ingredient cr_pate = new Ingredient("pâte à pizza", 1, "");
            Ingredient cr_cantal = new Ingredient("cantal", 20, "g");
            Ingredient cr_oignon = new Ingredient("oignons rouges", 1, "quart");
            Ingredient cr_tomates = new Ingredient("tomates", 1, "kg");
            Ingredient cr_ail = new Ingredient("ail", 1, "gousse");
            Ingredient cr_huile = new Ingredient("huilde d'olive", 1, "CàS");
            Ingredient cr_poivre = new Ingredient("poivre", 1, "pincée");
            Ingredient cr_miel = new Ingredient("miel", 1, "CàS");

            Ingredient[] ings_croissants = { cr_pate, cr_cantal, cr_oignon, cr_tomates, cr_ail, cr_poivre, cr_miel, cr_huile };
            croissants.AddIngs(ings_croissants);

            Recipe r_saumon = new Recipe("roulés", Category.Entree, "Roulés au saumon", "Intermédiaire", new List<Ingredient>(), 
                "Après avoir étalé la crème fraiche sur la pâte, déposez y les tranches de saumon de façon à recouvrir la quasi " +
                "totalité de la pâte.\n Saupoudrez ensuite d'emmental, d'aneth de poivre et de sel.\nRoulez la pâte sur elle-même" +
                " et laissez poser environ 20 minutes au congélateur.\n Une fois l'appareil reposé, coupez le en tranches puis  " +
                "enfournez à 220°C pendant 28 minutes.", 63, 3, new List<Rating>(), "r_saumon.jpg");


            Ingredient r_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient r_crème = new Ingredient("crème fraiche", 2, "CàS");
            Ingredient r_aneth = new Ingredient("aneth", 2, "pincées");
            Ingredient r_sau = new Ingredient("saumon", 4, "tranches");
            Ingredient r_emmental = new Ingredient("emmental", 100, "g");

            Ingredient[] ings_saumon = { r_pate, r_crème, r_aneth, r_sau, r_emmental };
            r_saumon.AddIngs(ings_saumon);

            Recipe f_fromage = new Recipe("feuilletés", Category.Aperitifs, "Feuilletés 2 fromages", "Facile", new List<Ingredient>(),
                "Coupez la pâte en 4, les chèvres en deux et la mozzarella en 16 tranches environ.\n Sur cahque triangle de pâte, " +
                "déposez 2 tranches de mozzarella et une moitié de chèvre, ajoutez une cuillère à soupe de crème et encore 2 tranches" +
                " de mozzarella. Salez, poivrez et enfourner 15 minutes à 200 °C", 25, 2, new List<Rating>(), "f_fromage.jpg");

            Ingredient f_pate = new Ingredient("pâte feuilletée", 1, "");
            Ingredient f_mozza = new Ingredient("mozzarella", 60, "g");
            Ingredient f_chèvre = new Ingredient("crottins de chèvre", 2, "");
            Ingredient f_creme = new Ingredient("crème épaisse", 4, "CàS");

            Ingredient[] ings_fromage = { f_chèvre, f_creme, f_mozza, f_pate };
            f_fromage.AddIngs(ings_fromage);


            Recipe r_pesto = new Recipe("roulés", Category.Entree, "Roulés au pesto", "Facile", new List<Ingredient>(),
                "Après avoir étalé le pesto sur la pâte, déposez y le parmesan de façon à recouvrir la quasi " +
                "totalité de la pâte.\n Saupoudrez ensuite de poivre et de sel puis roulez la pâte sur elle-même" +
                " et laissez poser environ 2 heures au congélateur.\n Une fois l'appareil reposé, coupez le en tranches puis badigeonnez" +
                " les rondelles de jaune d'oeur pour mieux les faire dorer et enfin enfournez à 180°C pendant 20 minutes.", 
                63, 3, new List<Rating>(), "r_pesto.jpg");


            Ingredient r_pest = new Ingredient("pesto", 1, "pot");
            Ingredient r_parm = new Ingredient("parmesan", 100, "g");
            Ingredient r_oeuf = new Ingredient("oeuf", 1, "");

            Ingredient[] ings_pesto = { r_pate, r_parm, r_pest, r_oeuf };
            r_pesto.AddIngs(ings_pesto);

            Recipe f_chorizo = new Recipe("feuilletés", Category.Aperitifs, "Feuilletés chorizo", "Facile", new List<Ingredient>(),
                "Commencez par enlever la peau du chorizo puis le couper en morceaux. Mixer ces morceaux avec le gruyèrs, l'oeuf et" +
                " la sauce tomate.\nEtaler le mélange sur la pâte puis la rouler sur elle-même et laisse reposer au congélateur 5 minutes." +
                " Couper la pâte en rondelles, puis enfourner 10 min à 180°C.", 30, 1, new List<Rating>(), "chorizo.jpg");

            Ingredient f_gruyere = new Ingredient("gruyère râpé", 70, "g");
            Ingredient f_sauce = new Ingredient("sauce tomate", 1, "petit bol");
            Ingredient f_oeuf = new Ingredient("oeuf", 1, "");
            Ingredient f_cho = new Ingredient("chorizo", 1, "demi");

            Ingredient[] ings_chorizo = {f_cho, f_gruyere, f_sauce, f_pate, f_oeuf};
            f_chorizo.AddIngs(ings_chorizo);


            Recipe quiche_lo = new Recipe("quiche", Category.Plat, "Quiche lorraine", "Facile", new List<Ingredient>(),
                "Dans une poêle, faire rissoler les lardons 5 minutes puis éponger le surplus de graisse avec un " +
                "essuie-tout.\n Battre les oeufs, le lait et la crème fraîche, y ajouter les lardons puis le sel, " +
                "poivre et muscade. Verser le mélange sur la pâte et saupoudrer de gruyère pour gratiner la quiche.\n" +
                "Enfournez pour 45 à 50 minutes à 180°C et c'est prêt !", 45, 1, new List<Rating>(), "quiche.jpg");

            Ingredient q_lardons = new Ingredient("lardons", 200, "g");
            Ingredient q_creme = new Ingredient("crème fraîche", 20, "cL");
            Ingredient q_epices = new Ingredient("sel, poivre", 1, "pincée");
            Ingredient q_oeufs = new Ingredient("oeufs", 3, "");
            Ingredient q_lait = new Ingredient("lait", 20, "cL");

            Ingredient[] ings_quiche = { q_creme, q_epices, q_lait, q_lardons, q_oeufs, f_pate };
            quiche_lo.AddIngs(ings_quiche);


            Recipe q_salmon = new Recipe("quiche", Category.Plat, "Quiche saumon épinards", "Intermédiaire", new List<Ingredient>(),
                "Après avoir déroulé la pâte dans un plat, y déposer les morceaux de saumon fumé. Dans une poêle à côté, faire " +
                " cuire les épinards avec une noix de beurre. Une fois cuits, les égoutter et couper en morceaux puis les ajouter" +
                " au saumon sur la pâte. Dans un saladier, mélanger les oeufs, la crème fraîche, le fromage, le sel et le poivre." +
                " Verser le mélange sur les épinards et le saumon répartis uniformément. Enfourner pour 40 minutes à 180°C.", 60, 3
                , new List<Rating>(), "q_saumon.jpeg");
            Ingredient q_cream = new Ingredient("crème fraîche épaisse", 10, "cL");
            Ingredient q_epinards = new Ingredient("épinards", 350, "g");
            Ingredient q_salm = new Ingredient("saumon fumé", 100, "g");
            Ingredient q_fromage = new Ingredient("fromage râpé", 100, "g");
            Ingredient q_beurre = new Ingredient("beurre", 1, "noix");

            Ingredient[] ings_q_s = { f_pate, q_oeufs, q_epices, q_cream, q_epinards, q_salm, q_fromage, q_beurre };
            q_salmon.AddIngs(ings_q_s);


            Recipe q_ch_j = new Recipe("quiche", Category.Plat, "Quiche champignons jambon", "Facile", new List<Ingredient>(),
                "Commencez par nettoyer les champignons puis coupez les en lamelles. Dans une poêle, faire revenir pendant " +
                "20 minutes les champignons avec une gousse d'ail et un peu d'huile. Ajouter le persil coupé ainsi que le " +
                "sel et le poivre. Dans un saladier à part, mélanger la crème fraîche et les oeufs. Disposer les tranches de" +
                " jambon sur le fond de la pâte et dans le mélange oeufs-crème ajouter les champignons puis verser le tout" +
                " sur le jambon. Ajouter le gruyère râpé par dessus et enfourner pour  40 minutes à 180 °C.", 60, 2,
                new List<Rating>(), "q_ch.jpg");

            Ingredient champ = new Ingredient("champignons de Paris", 500, "g");
            Ingredient persil = new Ingredient("persil", 1, "botte");
            Ingredient ail = new Ingredient("ail", 1, "gousse");
            Ingredient q_jambon = new Ingredient("jambon", 2, "tranches");
            Ingredient q_oeuf = new Ingredient("oeufs", 2, "");
            Ingredient q_fresh = new Ingredient("crème fraîche", 150, "g");
            Ingredient[] ings_ch = {f_pate, q_epices, champ, persil, ail, q_jambon, q_oeuf, q_fresh};

            q_ch_j.AddIngs(ings_ch);

            //Recipe t_mou = new Recipe("Quiche", Category.Plat, )


            Recipe[] recipes = { TartePommes, Soupe, sandwich, croissants, cookiefondant, f_fromage, 
            gaufre, r_saumon, moelleux, chouquettes, r_pesto, chaussonPommes, f_chorizo, roules_th, 
            roules_saucisse, torsades, quiche_lo, q_salmon};
            application.Recipes.AddRecipe(recipes);


            Account cpatrick = new Account("patrick", "patochelabrioche");
            Account calex = new Account("alex", "alexalexletrucsafe");
            Account lola = new Account("lola", "lolalola");

            application.Accounts.AddUser(cpatrick);
            application.Accounts.AddUser(calex);
            application.Accounts.AddUser(lola);

            cpatrick.AddFav(Soupe);
            calex.AddFav(TartePommes);

            lola.AddFav(TartePommes);
            lola.AddFav(r_pesto);

            Rating commsoupetest = new Rating(cpatrick, 4, "une bonne recette simple et efficace");
            Rating commconstructifsoupe = new Rating(calex, 2, "sympathique mais on a vite fait le tour (j'aime pas les choux)");
            Soupe.AddRating(commsoupetest);
            Soupe.AddRating(commconstructifsoupe);
            return application;
        }

        public void Save(Application application)
        {
            //pour chaque recipe qui n'existe pas on l'ajoute dans le stub

            for (int i = 0; i < application.Recipes.ListRecipes.Count; i++)
            {
                if (!Application.Recipes.ListRecipes.Contains(application.Recipes.ListRecipes[i]))
                {
                    Application.Recipes.ListRecipes.Add(application.Recipes.ListRecipes[i]);
                }
            }

            //pour chaque account qui n'existe pas on l'ajoute dans le stub

            foreach (string Name in application.Accounts.DictAccounts.Keys)
            {
                if (!Application.Accounts.DictAccounts.ContainsKey(Name))
                {
                    Application.Accounts.AddUser(application.Accounts.DictAccounts[Name]);
                }
            }
        }

    }
}
    