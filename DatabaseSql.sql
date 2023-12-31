PGDMP                      {            proje    16.1    16.1 ]               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16897    proje    DATABASE     �   CREATE DATABASE proje WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
    DROP DATABASE proje;
                postgres    false            �            1255    17292    aracdurum(text)    FUNCTION     �  CREATE FUNCTION public.aracdurum(textto text) RETURNS TABLE(idn integer, marka character, model character, durum character, idtedarikci integer, yil character)
    LANGUAGE plpgsql
    AS $$
BEGIN
IF textto = 'Yeni' THEN
    RETURN QUERY SELECT "aracId", "aracMarka", "aracModel", "aracDurum", "tedarikciId", "aracYil" FROM "Arac"
                 WHERE "aracDurum" = '10' or "aracDurum" = '9' or "aracDurum" = '8' or "aracDurum" = '7';
END IF;

IF textto = 'Orta' THEN
    RETURN QUERY SELECT "aracId", "aracMarka", "aracModel", "aracDurum", "tedarikciId", "aracYil" FROM "Arac"
                 WHERE "aracDurum" = '6' or "aracDurum" = '5' or "aracDurum" = '4';
END IF;

IF textto = 'Eski' THEN
    RETURN QUERY SELECT "aracId", "aracMarka", "aracModel", "aracDurum", "tedarikciId", "aracYil" FROM "Arac"
                 WHERE "aracDurum" = '3' or "aracDurum" = '2' or "aracDurum" = '1' or "aracDurum" = '0';
END IF;
END;
$$;
 -   DROP FUNCTION public.aracdurum(textto text);
       public          postgres    false            �            1255    17282    func1(character varying)    FUNCTION     �  CREATE FUNCTION public.func1(textto character varying) RETURNS TABLE(idn integer, isim character, vergino character, konum text, yoneticiisim character, calisansayi integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
IF textto = 'Buyuk' THEN
    RETURN QUERY SELECT "magazaId", "magazaIsim", "magazaVergiNo", "magazaKonum", "magazaYoneticiIsim", "magazaCalisanSayisi" FROM "Magaza"
                 WHERE "magazaCalisanSayisi" > 100;
END IF;

IF textto = 'Orta' THEN
    RETURN QUERY SELECT "magazaId", "magazaIsim", "magazaVergiNo", "magazaKonum", "magazaYoneticiIsim", "magazaCalisanSayisi" FROM "Magaza"
                 WHERE "magazaCalisanSayisi" <= 100 AND "magazaCalisanSayisi" > 50;
END IF;

IF textto = 'Kucuk' THEN
    RETURN QUERY SELECT "magazaId", "magazaIsim", "magazaVergiNo", "magazaKonum", "magazaYoneticiIsim", "magazaCalisanSayisi" FROM "Magaza"
                 WHERE "magazaCalisanSayisi" <= 50;
END IF;

END;
$$;
 6   DROP FUNCTION public.func1(textto character varying);
       public          postgres    false            �            1255    17289    gecmisreklamlar()    FUNCTION     O  CREATE FUNCTION public.gecmisreklamlar() RETURNS TABLE(reklamkanalid integer, reklaminkanaldasontarihi date)
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN QUERY SELECT "ReklamKanal"."reklamKanalId", "ReklamKanal"."reklaminKanaldaSonTarihi"
  FROM "ReklamKanal"
  WHERE "ReklamKanal"."reklaminKanaldaSonTarihi" < CURRENT_DATE;
END; $$;
 (   DROP FUNCTION public.gecmisreklamlar();
       public          postgres    false            �            1255    17287    maastoplam()    FUNCTION     
  CREATE FUNCTION public.maastoplam() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    sonuc int;
    rec RECORD;
BEGIN
	sonuc = 0;
    FOR rec IN SELECT * FROM "Calisan" LOOP
        sonuc := sonuc + rec."calisanMaas";
	END LOOP;
    RETURN sonuc;
END;
$$;
 #   DROP FUNCTION public.maastoplam();
       public          postgres    false            �            1255    17268    magazaadettrigger()    FUNCTION     �   CREATE FUNCTION public.magazaadettrigger() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "MagazaAdetBilgi" SET "magazaSayisi" = "magazaSayisi" + 1;
RETURN NEW;
END;
$$;
 *   DROP FUNCTION public.magazaadettrigger();
       public          postgres    false            �            1255    17269    magazaadettriggerdelete()    FUNCTION     �   CREATE FUNCTION public.magazaadettriggerdelete() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "MagazaAdetBilgi" SET "magazaSayisi" = "magazaSayisi" - 1;
RETURN NEW;
END;
$$;
 0   DROP FUNCTION public.magazaadettriggerdelete();
       public          postgres    false            �            1255    17272    materyeladettrigger()    FUNCTION     �   CREATE FUNCTION public.materyeladettrigger() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "MateryelAdetBilgi" SET "materyelSayisi" = "materyelSayisi" + 1;
RETURN NEW;
END;
$$;
 ,   DROP FUNCTION public.materyeladettrigger();
       public          postgres    false            �            1255    17273    materyeladettriggerdelete()    FUNCTION     �   CREATE FUNCTION public.materyeladettriggerdelete() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "MateryelAdetBilgi" SET "materyelSayisi" = "materyelSayisi" - 1;
RETURN NEW;
END;
$$;
 2   DROP FUNCTION public.materyeladettriggerdelete();
       public          postgres    false            �            1255    17264    urunadettrigger()    FUNCTION     �   CREATE FUNCTION public.urunadettrigger() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "UrunAdetBilgi" SET "urunSayisi" = "urunSayisi" + 1;
RETURN NEW;
END;
$$;
 (   DROP FUNCTION public.urunadettrigger();
       public          postgres    false            �            1255    17266    urunadettriggerdelete()    FUNCTION     �   CREATE FUNCTION public.urunadettriggerdelete() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
UPDATE "UrunAdetBilgi" SET "urunSayisi" = "urunSayisi" - 1;
RETURN NEW;
END;
$$;
 .   DROP FUNCTION public.urunadettriggerdelete();
       public          postgres    false            �            1259    16936    Arac    TABLE     Y  CREATE TABLE public."Arac" (
    "aracId" integer NOT NULL,
    "aracMarka" character(50),
    "aracModel" character(50),
    "aracDurum" character(50),
    "tedarikciId" integer NOT NULL,
    "aracYil" character(50),
    CONSTRAINT aracdurum_check CHECK ((("aracDurum" = '0'::bpchar) OR ("aracDurum" = '1'::bpchar) OR ("aracDurum" = '2'::bpchar) OR ("aracDurum" = '3'::bpchar) OR ("aracDurum" = '4'::bpchar) OR ("aracDurum" = '5'::bpchar) OR ("aracDurum" = '6'::bpchar) OR ("aracDurum" = '7'::bpchar) OR ("aracDurum" = '8'::bpchar) OR ("aracDurum" = '9'::bpchar) OR ("aracDurum" = '10'::bpchar)))
);
    DROP TABLE public."Arac";
       public         heap    postgres    false            �            1259    17134    Calisan    TABLE     �  CREATE TABLE public."Calisan" (
    "calisanId" integer NOT NULL,
    "calisanIsim" character varying(50),
    "calisanSoyisim" character varying(50),
    "calisanTc" character varying(11),
    "calisanMaas" integer,
    "calisanTipi" character(2) NOT NULL,
    "calisanAdres" text,
    CONSTRAINT calisantc_check CHECK ((length(("calisanTc")::text) = 11)),
    CONSTRAINT calisantipi_check CHECK ((("calisanTipi" = 'kp'::bpchar) OR ("calisanTipi" = 'mp'::bpchar) OR ("calisanTipi" = 'y'::bpchar)))
);
    DROP TABLE public."Calisan";
       public         heap    postgres    false            �            1259    17019    Kanal    TABLE     �   CREATE TABLE public."Kanal" (
    "kanalId" integer NOT NULL,
    "kanalAdi" character(50),
    "kanalNo" integer,
    "kanalMerkezKonum" text,
    "kanalYoneticiIsim" character(50)
);
    DROP TABLE public."Kanal";
       public         heap    postgres    false            �            1259    17173    KanalPersonel    TABLE     �   CREATE TABLE public."KanalPersonel" (
    "calisanId" integer NOT NULL,
    "kanalGorev" character varying(50),
    "kanalId" integer NOT NULL
);
 #   DROP TABLE public."KanalPersonel";
       public         heap    postgres    false            �            1259    16989    Magaza    TABLE     �   CREATE TABLE public."Magaza" (
    "magazaId" integer NOT NULL,
    "magazaIsim" character(50),
    "magazaVergiNo" character(50),
    "magazaKonum" text,
    "magazaYoneticiIsim" character(50),
    "magazaCalisanSayisi" integer
);
    DROP TABLE public."Magaza";
       public         heap    postgres    false            �            1259    16972    MagazaAdetBilgi    TABLE     F   CREATE TABLE public."MagazaAdetBilgi" (
    "magazaSayisi" integer
);
 %   DROP TABLE public."MagazaAdetBilgi";
       public         heap    postgres    false            �            1259    17146    MagazaPersonel    TABLE     �   CREATE TABLE public."MagazaPersonel" (
    "calisanId" integer NOT NULL,
    sirket character varying(50),
    "sirketTel" integer,
    "magazaId" integer NOT NULL
);
 $   DROP TABLE public."MagazaPersonel";
       public         heap    postgres    false            �            1259    17070 
   MagazaUrun    TABLE     �   CREATE TABLE public."MagazaUrun" (
    "magazaUrunId" integer NOT NULL,
    "urunId" integer NOT NULL,
    "magazaId" integer NOT NULL,
    bilgi text
);
     DROP TABLE public."MagazaUrun";
       public         heap    postgres    false            �            1259    16903    Materyel    TABLE     h   CREATE TABLE public."Materyel" (
    "materyelId" integer NOT NULL,
    "materyelIsim" character(50)
);
    DROP TABLE public."Materyel";
       public         heap    postgres    false            �            1259    16977    MateryelAdetBilgi    TABLE     J   CREATE TABLE public."MateryelAdetBilgi" (
    "materyelSayisi" integer
);
 '   DROP TABLE public."MateryelAdetBilgi";
       public         heap    postgres    false            �            1259    16947    Musteri    TABLE     �   CREATE TABLE public."Musteri" (
    "musteriId" integer NOT NULL,
    "musteriAdi" character(50),
    "musteriSoyadi" character(50),
    "musteriKonum" character(100),
    "musteriYorum" text
);
    DROP TABLE public."Musteri";
       public         heap    postgres    false            �            1259    17007    Reklam    TABLE       CREATE TABLE public."Reklam" (
    "reklamId" integer NOT NULL,
    "reklamIsim" character(50),
    "reklamSure" character(50),
    "reklamHedefKitle" text,
    "reklamUlkeleri" character(100),
    "reklamFirmasi" character(50),
    "urunId" integer NOT NULL
);
    DROP TABLE public."Reklam";
       public         heap    postgres    false            �            1259    17053    ReklamKanal    TABLE     �   CREATE TABLE public."ReklamKanal" (
    "reklamKanalId" integer NOT NULL,
    "reklamId" integer NOT NULL,
    "kanalId" integer NOT NULL,
    "reklaminKanaldaSonTarihi" date
);
 !   DROP TABLE public."ReklamKanal";
       public         heap    postgres    false            �            1259    16954    Siparis    TABLE     �   CREATE TABLE public."Siparis" (
    "siparisId" integer NOT NULL,
    "siparisYorum" text,
    "siparisKonum" text,
    "musteriId" integer NOT NULL,
    "magazaId" integer NOT NULL
);
    DROP TABLE public."Siparis";
       public         heap    postgres    false            �            1259    16923 	   Tedarikci    TABLE     �   CREATE TABLE public."Tedarikci" (
    "tedarikciId" integer NOT NULL,
    "tedarikciIsim" character(50),
    "tedarikciKonum" text,
    "urunId" integer
);
    DROP TABLE public."Tedarikci";
       public         heap    postgres    false            �            1259    16898    Urun    TABLE     �   CREATE TABLE public."Urun" (
    "urunId" integer NOT NULL,
    "urunAdi" character(50),
    "urunRenk" character(50),
    "materyelId" integer NOT NULL
);
    DROP TABLE public."Urun";
       public         heap    postgres    false            �            1259    17259    UrunAdetBilgi    TABLE     L   CREATE TABLE public."UrunAdetBilgi" (
    "urunSayisi" integer DEFAULT 0
);
 #   DROP TABLE public."UrunAdetBilgi";
       public         heap    postgres    false            �            1259    17141    Yonetici    TABLE     �   CREATE TABLE public."Yonetici" (
    "calisanId" integer NOT NULL,
    sirket character varying(50),
    bolum character varying(50)
);
    DROP TABLE public."Yonetici";
       public         heap    postgres    false            n          0    16936    Arac 
   TABLE DATA           k   COPY public."Arac" ("aracId", "aracMarka", "aracModel", "aracDurum", "tedarikciId", "aracYil") FROM stdin;
    public          postgres    false    218   �z       x          0    17134    Calisan 
   TABLE DATA           �   COPY public."Calisan" ("calisanId", "calisanIsim", "calisanSoyisim", "calisanTc", "calisanMaas", "calisanTipi", "calisanAdres") FROM stdin;
    public          postgres    false    228   x{       u          0    17019    Kanal 
   TABLE DATA           l   COPY public."Kanal" ("kanalId", "kanalAdi", "kanalNo", "kanalMerkezKonum", "kanalYoneticiIsim") FROM stdin;
    public          postgres    false    225   �|       {          0    17173    KanalPersonel 
   TABLE DATA           O   COPY public."KanalPersonel" ("calisanId", "kanalGorev", "kanalId") FROM stdin;
    public          postgres    false    231   �|       s          0    16989    Magaza 
   TABLE DATA           �   COPY public."Magaza" ("magazaId", "magazaIsim", "magazaVergiNo", "magazaKonum", "magazaYoneticiIsim", "magazaCalisanSayisi") FROM stdin;
    public          postgres    false    223   }       q          0    16972    MagazaAdetBilgi 
   TABLE DATA           ;   COPY public."MagazaAdetBilgi" ("magazaSayisi") FROM stdin;
    public          postgres    false    221   %~       z          0    17146    MagazaPersonel 
   TABLE DATA           X   COPY public."MagazaPersonel" ("calisanId", sirket, "sirketTel", "magazaId") FROM stdin;
    public          postgres    false    230   D~       w          0    17070 
   MagazaUrun 
   TABLE DATA           S   COPY public."MagazaUrun" ("magazaUrunId", "urunId", "magazaId", bilgi) FROM stdin;
    public          postgres    false    227   t~       l          0    16903    Materyel 
   TABLE DATA           B   COPY public."Materyel" ("materyelId", "materyelIsim") FROM stdin;
    public          postgres    false    216   �~       r          0    16977    MateryelAdetBilgi 
   TABLE DATA           ?   COPY public."MateryelAdetBilgi" ("materyelSayisi") FROM stdin;
    public          postgres    false    222          o          0    16947    Musteri 
   TABLE DATA           o   COPY public."Musteri" ("musteriId", "musteriAdi", "musteriSoyadi", "musteriKonum", "musteriYorum") FROM stdin;
    public          postgres    false    219   ;       t          0    17007    Reklam 
   TABLE DATA           �   COPY public."Reklam" ("reklamId", "reklamIsim", "reklamSure", "reklamHedefKitle", "reklamUlkeleri", "reklamFirmasi", "urunId") FROM stdin;
    public          postgres    false    224   ��       v          0    17053    ReklamKanal 
   TABLE DATA           k   COPY public."ReklamKanal" ("reklamKanalId", "reklamId", "kanalId", "reklaminKanaldaSonTarihi") FROM stdin;
    public          postgres    false    226   E�       p          0    16954    Siparis 
   TABLE DATA           i   COPY public."Siparis" ("siparisId", "siparisYorum", "siparisKonum", "musteriId", "magazaId") FROM stdin;
    public          postgres    false    220   ��       m          0    16923 	   Tedarikci 
   TABLE DATA           a   COPY public."Tedarikci" ("tedarikciId", "tedarikciIsim", "tedarikciKonum", "urunId") FROM stdin;
    public          postgres    false    217   �       k          0    16898    Urun 
   TABLE DATA           O   COPY public."Urun" ("urunId", "urunAdi", "urunRenk", "materyelId") FROM stdin;
    public          postgres    false    215   h�       |          0    17259    UrunAdetBilgi 
   TABLE DATA           7   COPY public."UrunAdetBilgi" ("urunSayisi") FROM stdin;
    public          postgres    false    232   Ƃ       y          0    17141    Yonetici 
   TABLE DATA           @   COPY public."Yonetici" ("calisanId", sirket, bolum) FROM stdin;
    public          postgres    false    229   �       �           2606    16940    Arac arac_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Arac"
    ADD CONSTRAINT arac_pkey PRIMARY KEY ("aracId");
 :   ALTER TABLE ONLY public."Arac" DROP CONSTRAINT arac_pkey;
       public            postgres    false    218            �           2606    17140    Calisan calisan_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Calisan"
    ADD CONSTRAINT calisan_pkey PRIMARY KEY ("calisanId");
 @   ALTER TABLE ONLY public."Calisan" DROP CONSTRAINT calisan_pkey;
       public            postgres    false    228            �           2606    17201    Calisan calisantc_unique 
   CONSTRAINT     \   ALTER TABLE ONLY public."Calisan"
    ADD CONSTRAINT calisantc_unique UNIQUE ("calisanTc");
 D   ALTER TABLE ONLY public."Calisan" DROP CONSTRAINT calisantc_unique;
       public            postgres    false    228            �           2606    17025    Kanal kanal_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Kanal"
    ADD CONSTRAINT kanal_pkey PRIMARY KEY ("kanalId");
 <   ALTER TABLE ONLY public."Kanal" DROP CONSTRAINT kanal_pkey;
       public            postgres    false    225            �           2606    17177     KanalPersonel kanalpersonel_pkey 
   CONSTRAINT     i   ALTER TABLE ONLY public."KanalPersonel"
    ADD CONSTRAINT kanalpersonel_pkey PRIMARY KEY ("calisanId");
 L   ALTER TABLE ONLY public."KanalPersonel" DROP CONSTRAINT kanalpersonel_pkey;
       public            postgres    false    231            �           2606    16995    Magaza magaza_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Magaza"
    ADD CONSTRAINT magaza_pkey PRIMARY KEY ("magazaId");
 >   ALTER TABLE ONLY public."Magaza" DROP CONSTRAINT magaza_pkey;
       public            postgres    false    223            �           2606    17150 "   MagazaPersonel magazapersonel_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."MagazaPersonel"
    ADD CONSTRAINT magazapersonel_pkey PRIMARY KEY ("calisanId");
 N   ALTER TABLE ONLY public."MagazaPersonel" DROP CONSTRAINT magazapersonel_pkey;
       public            postgres    false    230            �           2606    17076    MagazaUrun magazaurun_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."MagazaUrun"
    ADD CONSTRAINT magazaurun_pkey PRIMARY KEY ("magazaUrunId");
 F   ALTER TABLE ONLY public."MagazaUrun" DROP CONSTRAINT magazaurun_pkey;
       public            postgres    false    227            �           2606    16907    Materyel materyel_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."Materyel"
    ADD CONSTRAINT materyel_pkey PRIMARY KEY ("materyelId");
 B   ALTER TABLE ONLY public."Materyel" DROP CONSTRAINT materyel_pkey;
       public            postgres    false    216            �           2606    16953    Musteri musteri_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Musteri"
    ADD CONSTRAINT musteri_pkey PRIMARY KEY ("musteriId");
 @   ALTER TABLE ONLY public."Musteri" DROP CONSTRAINT musteri_pkey;
       public            postgres    false    219            �           2606    17013    Reklam reklam_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Reklam"
    ADD CONSTRAINT reklam_pkey PRIMARY KEY ("reklamId");
 >   ALTER TABLE ONLY public."Reklam" DROP CONSTRAINT reklam_pkey;
       public            postgres    false    224            �           2606    17057    ReklamKanal reklamkanal_pkey 
   CONSTRAINT     i   ALTER TABLE ONLY public."ReklamKanal"
    ADD CONSTRAINT reklamkanal_pkey PRIMARY KEY ("reklamKanalId");
 H   ALTER TABLE ONLY public."ReklamKanal" DROP CONSTRAINT reklamkanal_pkey;
       public            postgres    false    226            �           2606    16960    Siparis siparis_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Siparis"
    ADD CONSTRAINT siparis_pkey PRIMARY KEY ("siparisId");
 @   ALTER TABLE ONLY public."Siparis" DROP CONSTRAINT siparis_pkey;
       public            postgres    false    220            �           2606    16929    Tedarikci tedarikci_pkey 
   CONSTRAINT     c   ALTER TABLE ONLY public."Tedarikci"
    ADD CONSTRAINT tedarikci_pkey PRIMARY KEY ("tedarikciId");
 D   ALTER TABLE ONLY public."Tedarikci" DROP CONSTRAINT tedarikci_pkey;
       public            postgres    false    217            �           2606    16902    Urun urun_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Urun"
    ADD CONSTRAINT urun_pkey PRIMARY KEY ("urunId");
 :   ALTER TABLE ONLY public."Urun" DROP CONSTRAINT urun_pkey;
       public            postgres    false    215            �           2606    17145    Yonetici yonetici_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Yonetici"
    ADD CONSTRAINT yonetici_pkey PRIMARY KEY ("calisanId");
 B   ALTER TABLE ONLY public."Yonetici" DROP CONSTRAINT yonetici_pkey;
       public            postgres    false    229            �           1259    17069    fki_kanal_fkey    INDEX     M   CREATE INDEX fki_kanal_fkey ON public."ReklamKanal" USING btree ("kanalId");
 "   DROP INDEX public.fki_kanal_fkey;
       public            postgres    false    226            �           1259    17166    fki_magaza_fkey    INDEX     R   CREATE INDEX fki_magaza_fkey ON public."MagazaPersonel" USING btree ("magazaId");
 #   DROP INDEX public.fki_magaza_fkey;
       public            postgres    false    230            �           1259    16966    fki_musteri_fkey    INDEX     M   CREATE INDEX fki_musteri_fkey ON public."Siparis" USING btree ("musteriId");
 $   DROP INDEX public.fki_musteri_fkey;
       public            postgres    false    220            �           1259    17063    fki_reklam_fkey    INDEX     O   CREATE INDEX fki_reklam_fkey ON public."ReklamKanal" USING btree ("reklamId");
 #   DROP INDEX public.fki_reklam_fkey;
       public            postgres    false    226            �           1259    16946    fki_tedarikciid    INDEX     K   CREATE INDEX fki_tedarikciid ON public."Arac" USING btree ("tedarikciId");
 #   DROP INDEX public.fki_tedarikciid;
       public            postgres    false    218            �           1259    16935    fki_urun_fkey    INDEX     I   CREATE INDEX fki_urun_fkey ON public."Tedarikci" USING btree ("urunId");
 !   DROP INDEX public.fki_urun_fkey;
       public            postgres    false    217            �           2620    17275    Materyel triggeralti    TRIGGER        CREATE TRIGGER triggeralti AFTER DELETE ON public."Materyel" FOR EACH ROW EXECUTE FUNCTION public.materyeladettriggerdelete();
 /   DROP TRIGGER triggeralti ON public."Materyel";
       public          postgres    false    237    216            �           2620    17274    Materyel triggerbes    TRIGGER     x   CREATE TRIGGER triggerbes AFTER INSERT ON public."Materyel" FOR EACH ROW EXECUTE FUNCTION public.materyeladettrigger();
 .   DROP TRIGGER triggerbes ON public."Materyel";
       public          postgres    false    216    238            �           2620    17265    Urun triggerbir    TRIGGER     p   CREATE TRIGGER triggerbir AFTER INSERT ON public."Urun" FOR EACH ROW EXECUTE FUNCTION public.urunadettrigger();
 *   DROP TRIGGER triggerbir ON public."Urun";
       public          postgres    false    234    215            �           2620    17271    Magaza triggerdort    TRIGGER     {   CREATE TRIGGER triggerdort AFTER DELETE ON public."Magaza" FOR EACH ROW EXECUTE FUNCTION public.magazaadettriggerdelete();
 -   DROP TRIGGER triggerdort ON public."Magaza";
       public          postgres    false    223    236            �           2620    17267    Urun triggeriki    TRIGGER     v   CREATE TRIGGER triggeriki AFTER DELETE ON public."Urun" FOR EACH ROW EXECUTE FUNCTION public.urunadettriggerdelete();
 *   DROP TRIGGER triggeriki ON public."Urun";
       public          postgres    false    233    215            �           2620    17270    Magaza triggeruc    TRIGGER     s   CREATE TRIGGER triggeruc AFTER INSERT ON public."Magaza" FOR EACH ROW EXECUTE FUNCTION public.magazaadettrigger();
 +   DROP TRIGGER triggeruc ON public."Magaza";
       public          postgres    false    235    223            �           2606    17064    ReklamKanal kanal_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ReklamKanal"
    ADD CONSTRAINT kanal_fkey FOREIGN KEY ("kanalId") REFERENCES public."Kanal"("kanalId");
 B   ALTER TABLE ONLY public."ReklamKanal" DROP CONSTRAINT kanal_fkey;
       public          postgres    false    225    226    4789            �           2606    17178    KanalPersonel kanal_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."KanalPersonel"
    ADD CONSTRAINT kanal_fkey FOREIGN KEY ("kanalId") REFERENCES public."Kanal"("kanalId");
 D   ALTER TABLE ONLY public."KanalPersonel" DROP CONSTRAINT kanal_fkey;
       public          postgres    false    231    225    4789            �           2606    17183 "   KanalPersonel kanalpersonelcalisan    FK CONSTRAINT     �   ALTER TABLE ONLY public."KanalPersonel"
    ADD CONSTRAINT kanalpersonelcalisan FOREIGN KEY ("calisanId") REFERENCES public."Calisan"("calisanId") ON UPDATE CASCADE ON DELETE CASCADE;
 N   ALTER TABLE ONLY public."KanalPersonel" DROP CONSTRAINT kanalpersonelcalisan;
       public          postgres    false    228    4797    231            �           2606    17077    MagazaUrun magaza_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."MagazaUrun"
    ADD CONSTRAINT magaza_fkey FOREIGN KEY ("magazaId") REFERENCES public."Magaza"("magazaId");
 B   ALTER TABLE ONLY public."MagazaUrun" DROP CONSTRAINT magaza_fkey;
       public          postgres    false    227    223    4785            �           2606    17161    MagazaPersonel magaza_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."MagazaPersonel"
    ADD CONSTRAINT magaza_fkey FOREIGN KEY ("magazaId") REFERENCES public."Magaza"("magazaId");
 F   ALTER TABLE ONLY public."MagazaPersonel" DROP CONSTRAINT magaza_fkey;
       public          postgres    false    230    223    4785            �           2606    17167    Siparis magaza_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Siparis"
    ADD CONSTRAINT magaza_fkey FOREIGN KEY ("magazaId") REFERENCES public."Magaza"("magazaId");
 ?   ALTER TABLE ONLY public."Siparis" DROP CONSTRAINT magaza_fkey;
       public          postgres    false    4785    223    220            �           2606    17156 $   MagazaPersonel magazapersonelcalisan    FK CONSTRAINT     �   ALTER TABLE ONLY public."MagazaPersonel"
    ADD CONSTRAINT magazapersonelcalisan FOREIGN KEY ("calisanId") REFERENCES public."Calisan"("calisanId") ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY public."MagazaPersonel" DROP CONSTRAINT magazapersonelcalisan;
       public          postgres    false    228    4797    230            �           2606    16918    Urun materyel_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Urun"
    ADD CONSTRAINT materyel_fkey FOREIGN KEY ("materyelId") REFERENCES public."Materyel"("materyelId");
 >   ALTER TABLE ONLY public."Urun" DROP CONSTRAINT materyel_fkey;
       public          postgres    false    216    215    4772            �           2606    16961    Siparis musteri_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Siparis"
    ADD CONSTRAINT musteri_fkey FOREIGN KEY ("musteriId") REFERENCES public."Musteri"("musteriId");
 @   ALTER TABLE ONLY public."Siparis" DROP CONSTRAINT musteri_fkey;
       public          postgres    false    219    220    4780            �           2606    17058    ReklamKanal reklam_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ReklamKanal"
    ADD CONSTRAINT reklam_fkey FOREIGN KEY ("reklamId") REFERENCES public."Reklam"("reklamId");
 C   ALTER TABLE ONLY public."ReklamKanal" DROP CONSTRAINT reklam_fkey;
       public          postgres    false    226    224    4787            �           2606    16941    Arac tedarikciid    FK CONSTRAINT     �   ALTER TABLE ONLY public."Arac"
    ADD CONSTRAINT tedarikciid FOREIGN KEY ("tedarikciId") REFERENCES public."Tedarikci"("tedarikciId");
 <   ALTER TABLE ONLY public."Arac" DROP CONSTRAINT tedarikciid;
       public          postgres    false    218    217    4775            �           2606    16930    Tedarikci urun_fkey    FK CONSTRAINT     |   ALTER TABLE ONLY public."Tedarikci"
    ADD CONSTRAINT urun_fkey FOREIGN KEY ("urunId") REFERENCES public."Urun"("urunId");
 ?   ALTER TABLE ONLY public."Tedarikci" DROP CONSTRAINT urun_fkey;
       public          postgres    false    215    4770    217            �           2606    17014    Reklam urun_fkey    FK CONSTRAINT     y   ALTER TABLE ONLY public."Reklam"
    ADD CONSTRAINT urun_fkey FOREIGN KEY ("urunId") REFERENCES public."Urun"("urunId");
 <   ALTER TABLE ONLY public."Reklam" DROP CONSTRAINT urun_fkey;
       public          postgres    false    215    224    4770            �           2606    17082    MagazaUrun urun_fkey    FK CONSTRAINT     }   ALTER TABLE ONLY public."MagazaUrun"
    ADD CONSTRAINT urun_fkey FOREIGN KEY ("urunId") REFERENCES public."Urun"("urunId");
 @   ALTER TABLE ONLY public."MagazaUrun" DROP CONSTRAINT urun_fkey;
       public          postgres    false    4770    227    215            �           2606    17151    Yonetici yoneticicalisan    FK CONSTRAINT     �   ALTER TABLE ONLY public."Yonetici"
    ADD CONSTRAINT yoneticicalisan FOREIGN KEY ("calisanId") REFERENCES public."Calisan"("calisanId") ON UPDATE CASCADE ON DELETE CASCADE;
 D   ALTER TABLE ONLY public."Yonetici" DROP CONSTRAINT yoneticicalisan;
       public          postgres    false    229    228    4797            n   �   x���A
�0E�3��	��֪kA�R�p�&�P�ҁ���m������d���ꬓ3���F�{��="XKRX�c��F�.i���!H�)2"y�qI�9�=���f�l��g�A\�5�.脘�����H��#�A��6�Pr�ԇ����7)1����,�	BjLa�y��s�0�b��      x     x�E��j�0���+����J��4Mh��BO�(�p���8v���nN�1��K��n��G����$eYbyBa��S>���.M7C�ű��C��ܥ��'ԇ8�k��C1��}̝��6��W)�[W�L𕺌���Hb!,�n��æ�Ӹ`;Ʈ."v�����y�v��i:�#N	�ɑ��+xI�u��Ĥ{���*�M��pJg��Yq΋g�d5��n��ڃ�P��7X�[��s��lR��;�t������{�V��sQ�v`�      u   ,   x�3���/W 	pq::�p�$�e�(��g��+F��� e��      {      x�34�(�O)�.�/�4����� =z"      s     x����N�0��{�;i��.��!N\�`Z�Nk;��'���*=��_�8c�a#��2V�$ҏS(os�.ůP�>�؇<��C��6���V-g��te����P�Qp��c�̆��r�.�B�15+$���eA���Yr�p^f��(��qL�>XG�h�su����|��:�A_������b�a�)޲���z��A�\n�wD\[_��ُ9Ee�Fa�P�mi�����m���
Ghi:cݻhЗ\��׊����$�4\E�i������vz�      q      x������� � �      z       x�34��I��/K�412616�4����� H��      w   d   x�m�;�0�9='@�鏕�K0�P��p�3���8jEe�~������N��YEG��L���JڠFZ�PH�qC�6҄�Dj��q����s�j�T&      l   $   x�3��N,J��S pq�$�df��)F��� �G      r      x�3����� a �      o   >  x����n�0Eg�+�5��켃�M�4[�VB��R ��+'Egi17����X�J������?��`�'�ɗ5e����䖘�*h8t�����T
J�]�۱��V�P�U����V�3EbV.U2
x�[l���Z3<#�;�-W��a���Y.�mO��IFA�֪Q����)��'X���X���b��3�U�d�۱E�6���M�����c9�r�o�t�smН�U��i��>�hCLM����[%�178��zd�j*䓘���<�^1�dG���1|���u�21y�&��d
�SH)_�(�      t   �   x���A�0E��S� �H1�хagĘ��`B
�4)`RO/ޠ���_��N��3ɛ:�����u�b�	�rv�22z�/~\�L�_��%v$��u9�L�J�̖��.$-����2]Ioy&�'��Z�QŖ�|�'�v��kܖ)`������Hj��>I5
��)�~ �E      v   /   x�3�4B##c]CC �2�4���rs�,u�b���� �u�      p   ~   x��M
�0��7��	Is�Q��ƍ�fj�&)�G���������!���襝�
��r5ǵ�{fu�>jL�%iL\*d1fu���)�5}˰�d����8J�Hn�q^z����&�?M�&�      m   F   x�3�(��S 	pz�$�%��prq���T�f�c^vbQ"��1�[Qfzn"i�W�fqs��qqq ��!      k   N   x�3�t��I�,N�L,R p'e��Őˈ3$5'5-?�mN���U��d�e����M��3+3H�b����� �W1L      |      x�3����� h �      y   g   x�3�I-�I�t-�,��I�M��2�N�-.�KG4����+.I-B4�t,(�IE2���+I�A2�t�MA0�tN���C��tLF5ے�'5/��e1z\\\ ��:�     