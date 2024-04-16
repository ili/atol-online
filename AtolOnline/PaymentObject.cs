﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtolOnline.Unofficial;
/// <summary>
/// <list type="bullet">
/// <listheader><term>Признак предмета расчёта</term> </listheader>
/// 
/// <item>
/// <term>1</term>
/// <description>
/// о реализуемом товаре, за исключением подакцизного товара и товара, подлежащего маркировке средствами идентификации (наименование и иные сведения, описывающие товар)
/// </description>
/// </item>
/// 
/// <item>
/// <term>2</term>
/// <description>
/// о реализуемом подакцизном товаре, за исключением товара, подлежащего маркировке средствами идентификации (наименование и иные сведения, описывающие товар)
/// </description>
/// </item>
/// 
/// <item><term>3</term>
/// <description>
/// о выполняемой работе (наименование и иные сведения, описывающие работу)
/// </description>
/// </item>
/// 
/// <item><term>4</term>
/// <description>
/// об оказываемой услуге (наименование и иные сведения, описывающие услугу)
/// </description>
/// </item>
/// 
/// <item><term>5</term>
/// <description>
/// о приеме ставок при осуществлении деятельности по проведению азартных игр
/// </description>
/// </item>
/// 
/// <item><term>6</term>
/// <description>
/// о выплате денежных средств в виде выигрыша при осуществлении деятельности по проведению азартных игр
/// </description>
/// </item>
/// 
/// <item><term>7</term>
/// <description>
/// о приеме денежных средств при реализации лотерейных билетов, электронных лотерейных билетов, приеме лотерейных ставок при осуществлении деятельности по проведению лотерей
/// </description>
/// </item>
/// 
/// <item><term>8</term>
/// <description>
/// о выплате денежных средств в виде выигрыша при осуществлении деятельности по проведению лотерей
/// </description>
/// </item>
/// 
/// <item><term>9</term>
/// <description>
/// о предоставлении прав на использование результатов интеллектуальной деятельности или средств индивидуализации
/// </description>
/// </item>
/// 
/// <item><term>10</term>
/// <description>
/// об авансе, задатке, предоплате, кредит
/// </description>
/// </item>
/// 
/// <item><term>11</term>
/// <description>
/// о вознаграждении пользователя, являющегося платежным агентом(субагентом), банковским платежным агентом(субагентом), комиссионером, поверенным или иным агентом
/// </description>
/// </item>
/// 
/// <item><term>12</term>
/// <description>
/// о взносе в счет оплаты, пени, штрафе, вознаграждении, бонусе и ином аналогичном предмете расчета
/// </description>
/// </item>
/// 
/// <item><term>13</term>
/// <description>
/// о предмете расчета, не относящемуся к предметам расчета, которым может быть присвоено значение от «1» до «11» и от «14» до «26»
/// </description>
/// </item>
/// 
/// <item><term>14</term>
/// <description>
/// о передаче имущественных прав
/// </description>
/// </item>
/// 
/// <item><term>15</term>
/// <description>
/// о внереализационном доходе
/// </description>
/// </item>
/// 
/// <item><term>16</term>
/// <description>
/// о суммах расходов, платежей и взносов, указанных в подпунктах 2 и 3 пункта Налогового кодекса Российской Федерации, уменьшающих сумму налога
/// </description>
/// </item>
/// 
/// <item><term>17</term>
/// <description>
/// о суммах уплаченного торгового сбора
/// </description>
/// </item>
/// 
/// <item><term>18</term>
/// <description>
/// о курортном сборе
/// </description>
/// </item>
/// 
/// <item><term>19</term>
/// <description>
/// о залоге
/// </description>
/// </item>
/// 
/// <item><term>20</term>
/// <description>
/// о суммах произведенных расходов в соответствии со статьей 346.16 Налогового кодекса Российской Федерации, уменьшающих доход
/// </description>
/// </item>
/// 
/// <item><term>21</term>
/// <description>
/// о страховых взносах на обязательное пенсионное страхование, уплачиваемых ИП, не производящими выплаты и иные вознаграждения физическим лицам
/// </description>
/// </item>
/// 
/// <item><term>22</term>
/// <description>
/// о страховых взносах на обязательное пенсионное страхование, уплачиваемых организациями и ИП, производящими выплаты и иные вознаграждения физическим лицам
/// </description>
/// </item>
/// 
/// <item><term>23</term>
/// <description>
/// о страховых взносах на обязательное медицинское страхование, уплачиваемых ИП, не производящими выплаты и иные вознаграждения физическим лицам
/// </description>
/// </item>
/// 
/// <item><term>24</term>
/// <description>
/// о страховых взносах на обязательное медицинское страхование, уплачиваемые организациями и ИП, производящими выплаты и иные вознаграждения физическим лицам
/// </description>
/// </item>
/// 
/// <item><term>25</term>
/// <description>
/// о страховых взносах на обязательное социальное страхование на случай временной нетрудоспособности и в связи с материнством, на обязательное социальное страхование от несчастных случаев на производстве и профессиональных заболеваний
/// </description>
/// </item>
/// 
/// <item><term>26</term>
/// <description>
/// о приеме и выплате денежных средств при осуществлении казино и залами игровых автоматов расчетов с использованием обменных знаков игорного заведения
/// </description>
/// </item>
/// 
/// <item><term>27</term>
/// <description>
/// о выдаче денежных средств банковским платежным агентом
/// </description>
/// </item>
/// 
/// <item><term>30</term>
/// <description>
/// о реализуемом подакцизном товаре, подлежащем маркировке средством идентификации, не имеющем кода маркировки
/// </description>
/// </item>
/// 
/// <item><term>31</term>
/// <description>
/// о реализуемом подакцизном товаре, подлежащем маркировке средством идентификации, имеющем код маркировки
/// </description>
/// </item>
/// 
/// <item><term>32</term>
/// <description>
/// о реализуемом товаре, подлежащем маркировке средством идентификации, не имеющем кода маркировки, за исключением подакцизного товара
/// </description>
/// </item>
/// 
/// <item><term>33</term>
/// <description>
/// о реализуемом товаре, подлежащем маркировке средством идентификации, имеющем код маркировки, за исключением подакцизного товара
/// </description>
/// </item>
/// 
/// </list>
/// </summary>

